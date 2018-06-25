using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class Game : PersistableObject
{
    public PersistentStorage storage;
    public ShapeFactory shapeFactory;
    public KeyCode createCubeKey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    public KeyCode saveKey = KeyCode.S;
    public KeyCode loadKey = KeyCode.L;
    private List<Shape> shapes;

    // Use this for initialization
    void Awake ()
    {
        shapes = new List<Shape>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(createCubeKey))
        {
            CreateObject();
        }
        else if (Input.GetKey(newGameKey))
        {
            BeginNewGame();
        }
        else if (Input.GetKeyDown(saveKey))
        {
            storage.Save(this);
        }
        else if (Input.GetKeyDown(loadKey))
        {
            BeginNewGame();
            storage.Load(this);
        }
    }

    public override void Save(GameDataWriter writer)
    {
        writer.Write(shapes.Count);
        shapes.ForEach(c => { writer.Write(c.ShapeId); c.Save(writer); });
    }

    public override void Load(GameDataReader reader)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
        {
            int shapeId = reader.ReadInt();
            Shape shape = shapeFactory.Get(shapeId);
            shape.Load(reader);
            shapes.Add(shape);
        }
    }

    void BeginNewGame() {
        shapes.ForEach(c => Destroy(c.gameObject));
        shapes.Clear();
    }

    void CreateObject()
    {
        Shape newShape = shapeFactory.GetRandom();
        Transform shapeTransform = newShape.transform;
        shapeTransform.localPosition = Random.insideUnitSphere * 5f;
        shapeTransform.localRotation = Random.rotation;
        shapeTransform.localScale = Vector3.one * Random.Range(0.1f, 1f);
        shapes.Add(newShape);
    }
}
