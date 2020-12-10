using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab6
{
    public class Radius
    {
        private double radius { get; set; }

        public Radius()
        {
            radius = 0;
        }
        public Radius(double rad)
        {
            radius = rad;
        }
        public void readRadius()
        {
            Console.Write("Радиус = ");
            this.radius = Convert.ToDouble(Console.ReadLine().ToString());
        }
        public void displayRadius()
        {
            Console.Write(radius);
        }
        public Object addRadius(Radius rad1, Radius rad2)
        {
            this.radius = rad1.radius + rad2.radius;
            return this;
        }
        public double returnRadius()
        {
            return radius;
        }
        public static Radius operator ++(Radius rad)
        {
            ++rad.radius;
            return rad;
        }

    }
    public class Vector
    {
        private double X { get; set; }
        private double Y { get; set; }
        private double Z { get; set; }
        private Radius cylinderRadius { get; set; }
        public static int countOfVector = 0;

        public Vector()
        {
            Radius rad = new Radius(0);
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.cylinderRadius = rad;
            countOfVector++;
        }

        public Vector(double x, double y, double z, Radius rad)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.cylinderRadius = rad;
            countOfVector++;
        }
        public Vector(int n)
        {
            Radius rad = new Radius(n);
            this.X = n;
            this.Y = n;
            this.Z = n;
            this.cylinderRadius = rad;
            countOfVector++;
        }
        ~Vector()
        {
            if (countOfVector > 0)
                countOfVector--;
        }
        public static int GetCountOfVector()
        {
            return countOfVector;
        }
        public void read()
        {
            Console.Write("x = ");
            this.X = Convert.ToDouble(Console.ReadLine().ToString());
            Console.Write("y = ");
            this.Y = Convert.ToDouble(Console.ReadLine().ToString());
            Console.Write("z = ");
            this.Z = Convert.ToDouble(Console.ReadLine().ToString());
            this.cylinderRadius.readRadius();
        }
        public void display()
        {
            Console.Write(this.X + "; " + this.Y + "; " + this.Z);
            Console.Write(", радиус = ");
            this.cylinderRadius.displayRadius();
        }
        public Vector add(Vector vector)
        {
            Radius rad = new Radius(0.0);
            Vector c = new Vector(0, 0, 0, rad);
            c.X = this.X + vector.X;
            c.Y = this.Y + vector.Y;
            c.Z = this.Z + vector.Z;
            c.cylinderRadius.addRadius(this.cylinderRadius, vector.cylinderRadius);
            return this;
        }
        public double length()
        {
            double length = Math.Pow(this.X * this.X + this.Y * this.Y + this.Z * this.Z, 0.5);
            return length;
        }
        public void scalar(Vector vector, out double scalar)
        {
            scalar = this.X * vector.X + this.Y * vector.Y + this.Z * vector.Z;
        }
        public void cylinderVolume(ref double volume)
        {
            volume = this.cylinderRadius.returnRadius() * this.cylinderRadius.returnRadius() * this.length() * 3.14;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Radius rad = new Radius(0.0);
            Vector c = new Vector(0, 0, 0, rad);
            c.X = vector1.X + vector2.X;
            c.Y = vector1.Y + vector2.Y;
            c.Z = vector1.Z + vector2.Z;
            c.cylinderRadius.addRadius(vector1.cylinderRadius, vector2.cylinderRadius);
            return c;
        }

        public static Vector operator ++(Vector vector)
        {
            ++vector.X;
            ++vector.Y;
            ++vector.Z;
            ++vector.cylinderRadius;
            return vector;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String str = "Работа с векторами и радиусами цилиндров.";
            int length_str = str.Length;
            Console.WriteLine(str);
            Console.WriteLine("Длина строки " + length_str);

            Radius rad = new Radius(1.5);
            Vector a = new Vector();
            Vector c = new Vector();
            Vector b = new Vector(1, 0, -2, rad);
            Console.WriteLine("Количество созданных векторов: " + Vector.GetCountOfVector());
            Console.WriteLine("Введите координаты и радиус a:");
            a.read();
            Console.WriteLine("Цилиндры:");
            Console.Write("a ");
            a.display();
            Console.WriteLine();
            Console.Write("b ");
            b.display();
            Console.WriteLine("");
            b++;
            Console.Write("b ");
            b.display();
            Console.WriteLine("");
            ++b;
            Console.Write("b ");
            b.display();
            Console.WriteLine("");

            Console.WriteLine("Сложение цилиндров a и b: ");
            c = a + b;
            Console.Write("c ");
            c.display();
            Console.WriteLine("\nДлина вектора a равна " + a.length());
            double volume = 0;
            a.cylinderVolume(ref volume);
            Console.WriteLine("Объем цилиндра a равен " + volume);
            double scalar;
            a.scalar(b, out scalar);
            Console.WriteLine("Скалярное произведение векторов a и b равно " + scalar);

            Console.WriteLine("Работа с массивом объектов.");
            Vector[] arr = new Vector[3];
            for (int i = 0; i < 3; i++)
                arr[i] = new Vector(i);
            //arr[0] = a;
            //arr[1] = b;
            //arr[2] = c;
            Console.WriteLine("Количество созданных векторов: " + Vector.GetCountOfVector());
            arr[0].read();

            Console.WriteLine("Цилиндры:");
            Console.Write("arr[0] ");
            arr[0].display();
            Console.WriteLine();
            Console.Write("arr[1] ");
            arr[1].display();
            Console.WriteLine("");

            Console.WriteLine("Сложение цилиндров arr[0] и arr[1]: ");
            arr[2] = arr[0] + arr[1];
            Console.Write("arr[2] ");
            arr[2].display();
            Console.WriteLine("\nДлина вектора arr[0] равна " + arr[0].length());
            double volume_arr = 0;
            a.cylinderVolume(ref volume_arr);
            Console.WriteLine("Объем цилиндра arr[0] равен " + volume_arr);
            double scalar_arr;
            a.scalar(b, out scalar_arr);
            Console.WriteLine("Скалярное произведение векторов arr[0] и arr[1] равно " + scalar_arr);

        }
    }
}
