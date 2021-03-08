using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Multitone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multiton design patter!");
            Camera camera1 = Camera.GetCamera("Canon");
            Camera camera2 = Camera.GetCamera("Canon");
            Camera camera3 = Camera.GetCamera("Nikon");
            Camera camera4 = Camera.GetCamera("Nikon");
            Camera camera5 = Camera.GetCamera("Elma");
            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);
            Console.WriteLine(camera5.Id);
        }
    }

//Camera=>Multiton design patter
    class Camera
    {
        private static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        private static object _lock = new object();
        public Guid Id { get; set; }
        public static string Name { get; set; }
        public string NameVer { get; set; }

        public Camera()
        {
            Id = Guid.NewGuid();
            NameVer = Name;
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                    Name = brand;
                }
            }

            return _cameras[brand];
        }
    }
}