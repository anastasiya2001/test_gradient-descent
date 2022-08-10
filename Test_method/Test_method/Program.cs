class Program
{
    public static void steepestDescent(double[] x, double alpha, double tolerance)
    {
        int n = x.Length; //Size of input array
        double h = 1e-6;  //Tolerance factor
        double g0 = g(x); //Initial estimate of result

        //Calculate initial gradient
        double[] fi = new double[n];
        fi = GradG(x, h);

        //Calculate initial norm
        double DelG = 0;
        for (int i = 0; i < n; ++i)
            DelG += fi[i] * fi[i];
        DelG = Math.Sqrt(DelG);

        double b = alpha / DelG;

        //Iterate until value is <= tolerance limit
        while (DelG > tolerance)
        {
            //Calculate next value
            for (int i = 0; i < n; ++i)
                x[i] -= b * fi[i];
            h /= 2;

            //Calculate next gradient
            fi = GradG(x, h);

            //Calculate next norm 
            DelG = 0;
            for (int i = 0; i < n; ++i)
                DelG += fi[i] * fi[i];
            DelG = Math.Sqrt(DelG);

            b = alpha / DelG;

            //Check value of given function
            //with current values
            double g1 = g(x);

            //Adjust parameter
            if (g1 > g0) alpha /= 2;
            else g0 = g1;
        }
    }

    public static double[] GradG(double[] x, double h)
    {
        int n = x.Length;
        double[] z = new double[n];
        double[] y = (double[])x.Clone();
        double g0 = g(x);
        for (int i = 0; i < n; ++i)
        {
            y[i] += h;
            z[i] = (g(y) - g0) / h;
        }
        return z;
    }

    public static double g(double[] x)
    {
        return x[0] + x[1] - x[2] * 2 - x[3] * 0.1 + x[4] - x[5] - x[6] * 5 + x[7] + x[8] - 3 - x[9] / 1.5 + x[10] + x[11] - x[12];
    }

    static void Main(string[] args)
    {
        double tolerance = 100000;
        double alpha = 0.1;
        double[] x = new double[13];
        x[0] = 0.1; 
        x[1] = -1;  
        steepestDescent(x, alpha, tolerance);
        Console.WriteLine("The minimum is at x[0] = " + x[0] + ", x[1] = " + x[1]);
        Console.ReadLine();

    }
}