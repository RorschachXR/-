using System;
using System.Numerics;
namespace Project1_ShapeClass
{

    public interface baseShape
    {
        const float eps = 0.000001f; 
        bool isValid();
        float calcArea();
        void checkValidity();
    }
    class InvalidFigureException: Exception
    {
        public InvalidFigureException()
        {
            Console.WriteLine("Invalid Figure!");
        }
    }
    public class Rectangle:baseShape
    {
        protected const float eps = 0.000001f;
        protected Vector2 leftUp, leftDown, rightUp, rightDown;
        public bool Zero(float x)
        {
            if (Math.Abs(x) < eps) return true;
            return false;
        }
        public Vector2 LeftUp
        {
            get => leftUp;
            set => leftUp = value;
        }
        public Vector2 LeftDown
        {
            get => leftDown;
            set => leftDown = value;
        }
        public Vector2 RightUp
        {
            get => RightUp;
            set => RightUp = value;
        }
        public Vector2 RightDown
        {
            get => rightDown;
            set => rightDown = value;
        }
        public Rectangle(float lux,float luy,float ldx,float ldy,float rux,float ruy,float rdx,float rdy)
        {
            leftUp = new Vector2(lux, luy);
            leftDown = new Vector2(ldx, ldy);
            rightUp = new Vector2(rux, ruy);
            rightDown = new Vector2(rdx, rdy);
        }
        
        public virtual bool isValid()
        {
            Vector2 v1 = rightUp - leftUp, v2 = leftDown - leftUp,v3=rightDown-leftDown,v4=rightDown-rightUp;
            if (!Zero(Vector2.Dot(v1, v2))|| !Zero(Vector2.Dot(v3, v2))|| !Zero(Vector2.Dot(v3, v4))|| !Zero(Vector2.Dot(v1, v4))) return false;
            return true;
        }
        public virtual void checkValidity()
        {
            if (!isValid()) throw new InvalidFigureException();
        }
        public virtual float calcArea()
        {

            //yichangchuli 
            try
            {
                checkValidity();
            }
            catch(InvalidFigureException ex)
            {
                throw ex;
            }
            return Vector2.Distance(rightUp, rightDown) * Vector2.Distance(leftDown, rightDown);
        }
    }
    public class Square:Rectangle
    {
        public Square(float lux, float luy, float ldx, float ldy, float rux, float ruy, float rdx, float rdy):base(lux, luy, ldx, ldy, rux, ruy, rdx, rdy)
        {

        }

        public override bool isValid()
        {
            if (!base.isValid()) return false;
            float edge1 = Vector2.Distance(leftUp, leftDown);
            float edge2 = Vector2.Distance(rightDown, leftDown);


            if (Math.Abs(edge1-edge2)>eps) return false;


            return true;
        }
        public override void checkValidity()
        {
            if (!isValid()) throw new InvalidFigureException();
        }
        public override float calcArea()
        {

            //yichangchuli 
            try
            {
                checkValidity();
            }
            catch (InvalidFigureException ex)
            {
                throw ex;
            }
            return Vector2.Distance(rightUp, rightDown) * Vector2.Distance(leftDown, rightDown);
        }
    }
    public class Delta:baseShape
    {
        Vector2 p1, p2, p3;
        const float eps = 0.000001f;
        public Vector2 P1
        {
            get => p1;
            set => p1 = value;
        }
        public Vector2 P2
        {
            get => p2;
            set => p2 = value;
        }
        public Vector2 P3
        {
            get => p3;
            set => p3 = value;
        }
        public Delta(float p1x,float p1y,float p2x,float p2y,float p3x,float p3y)
        {
            p1 = new Vector2(p1x, p1y);
            p2 = new Vector2(p2x, p2y);
            p3 = new Vector2(p3x, p3y);
        }
        public bool Zero(float x)
        {
            if (Math.Abs(x) < eps) return true;
            return false;
        }
        public bool isValid()
        {
            Vector2 e1 = p2 - p1, e2 = p3 - p2, e3 = p3 - p1;
            float edge1 = Vector2.Distance(p1, p2), edge2 = Vector2.Distance(p2, p3), edge3 = Vector2.Distance(p1, p3);
            if (Zero(edge1) || Zero(edge2) || Zero(edge3)) return false;
            if (e1==e2||e2==e3||e3==e1) return false;
            return true;

        }
        public void checkValidity()
        {
            if (!isValid()) throw new InvalidFigureException();
        }
        public float calcArea()
        {
            try
            {
                checkValidity();
            }
            catch(InvalidFigureException ex)
            {
                throw ex;
            }
            float edge1 =Vector2.Distance(p1,p2), edge2 = Vector2.Distance(p2,p3),edge3=Vector2.Distance(p1,p3);
            float p = (edge1 + edge2 + edge3) * 0.5f;
            return (float)Math.Sqrt(p * (p - edge1) * (p - edge2) * (p - edge3));
        }

    }
    public class FigureFactory
    {
        const int MAX = (int)1000000007;
        const int MIN = -MAX;
        public static baseShape createFigure(int type)
        {
            Random a = new Random();
            int leftUpX, leftUpY, l, w;
            baseShape res = null;
            switch(type)
            {
                case 0:
                    leftUpX = a.Next(MIN, MAX);
                    leftUpY = a.Next(MIN, MAX);
                    l = a.Next();
                    w = a.Next();
                    res= new Rectangle(leftUpX, leftUpY, leftUpX, leftUpY - w, leftUpX + l, leftUpY, leftUpX + l, leftUpY - w);
                    break;
                case 1:
                    leftUpX = a.Next(MIN, MAX);
                    leftUpY = a.Next(MIN, MAX);
                    l = a.Next();
                    res= new Square(leftUpX, leftUpY, leftUpX, leftUpY - l, leftUpX + l, leftUpY, leftUpX + l, leftUpY - l);
                    break;
                case 2:
                    int p1x = a.Next(MIN, MAX), p2x = a.Next(MIN, MAX), p3x = a.Next(MIN, MAX), p1y = a.Next(MIN, MAX), p2y = a.Next(MIN, MAX), p3y = a.Next(MIN, MAX);
                    res= new Delta(p1x, p1y, p2x, p2y, p3x, p3y);
                    break;

            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FigureFactory ff;
            Random rand = new Random();
            int n = 10;
            float sum = 0,Area=0;
            for(int i=1;i<=n;i++)
            {
                int type = rand.Next() % 3;
                try
                {
                    Area=FigureFactory.createFigure(type).calcArea();
                }
                catch(InvalidFigureException ex)
                {

                    //Console.WriteLine("NOWTYPE " + type);

                    n++;continue;
                }
                sum += Area;
            }
            Console.WriteLine(sum);
        }
    }
}
