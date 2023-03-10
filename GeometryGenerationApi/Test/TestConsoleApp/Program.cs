// See https://aka.ms/new-console-template for more information
using GeometryGeneration.BezierCurveGeneration.Models;
using GeometryGeneration.MathCalculations.Models;
using Newtonsoft.Json;
using ParametersManager.Managers;
using ParametersManager.Models;

//var a = new ConfigManager().GetConfig();
//Console.WriteLine(JsonConvert.SerializeObject(a));
//Console.WriteLine("----------------------------------------------------------------------");
//var b = new ConfigManager().GetConfig(a.Types.First().Key);
//Console.WriteLine(JsonConvert.SerializeObject(b));
//Console.ReadKey();

//var curve = new CubicBezierCurve3(
//    new Matrix4(new Vector3D(0, 1, 0), new Vector3D(0, 0, 0), new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)),
//    new Matrix4(new Vector3D(0, 1, 0), new Vector3D(0, 0, 0), new Vector3D(0, 0, 0), new Vector3D(1, 0, 0))
//);

//for (int i = 0; i < 11; i++)
//{
//    var t = i / 10.0;
//    Console.WriteLine(t.ToString().PadRight(25, '_').PadLeft(50, '_'));
//    Console.WriteLine(curve.GetPoint(t).BaseX);
//    //Console.Write(curve.GetPoint(i/10.0));
//}

//Console.WriteLine("".PadLeft(50, '#'));
//Console.Write(curve.GetPoint(0));
//Console.WriteLine("".PadLeft(50, '#'));
//Console.Write(curve.GetPoint(0.5));
//Console.WriteLine("".PadLeft(50, '#'));
//Console.Write(curve.GetPoint(1));
//Console.WriteLine("".PadLeft(50, '#'));

//var m = Matrix4.MakeRotationAxis(new Vector3D(0, 0, 1), -Math.PI/2);
//var v = new Vector3D(1, 0, 0);
//Console.Write(v.ApplyMatrix4(m).ToString());

//var testJSchema = new JSchema
//{
//    Type = JSchemaType.Object,
//    Title = "Test",
//    Description = "Desc",
//    Properties = null,
//    Enum = new List<string> { "Test1" },
//    ReadOnly = false,
//    Regex = "test%"
//};

var test2JSchema = JSchemaManager.Instance.GetConfig<BezierCurveGenerationParameters>();

Console.WriteLine(test2JSchema.ToString());

Console.ReadKey();