using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labwork
{
    public class gammafunc
    {
        /*************************************************************************
        Gamma function

        Input parameters:
            X   -   argument

        Domain:
            0 < X < 171.6
            -170 < X < 0, X is not an integer.

        Relative error:
         arithmetic   domain     # trials      peak         rms
            IEEE    -170,-33      20000       2.3e-15     3.3e-16
            IEEE     -33,  33     20000       9.4e-16     2.2e-16
            IEEE      33, 171.6   20000       2.3e-15     3.2e-16

        Cephes Math Library Release 2.8:  June, 2000
        Original copyright 1984, 1987, 1989, 1992, 2000 by Stephen L. Moshier
        Translated to AlgoPascal by Bochkanov Sergey (2005, 2006, 2007).
        *************************************************************************/
        public static double gammafunction(double x)
        {
            double result = 0;
            double p = 0;
            double pp = 0;
            double q = 0;
            double qq = 0;
            double z = 0;
            int i = 0;
            double sgngam = 0;

            sgngam = 1;
            q = Math.Abs(x);
            if ((double)(q) > (double)(33.0))
            {
                if ((double)(x) < (double)(0.0))
                {
                    p = (int)Math.Floor(q);
                    i = (int)Math.Round(p);
                    if (i % 2 == 0)
                    {
                        sgngam = -1;
                    }
                    z = q - p;
                    if ((double)(z) > (double)(0.5))
                    {
                        p = p + 1;
                        z = q - p;
                    }
                    z = q * Math.Sin(Math.PI * z);
                    z = Math.Abs(z);
                    z = Math.PI / (z * gammastirf(q));
                }
                else
                {
                    z = gammastirf(x);
                }
                result = sgngam * z;
                return result;
            }
            z = 1;
            while ((double)(x) >= (double)(3))
            {
                x = x - 1;
                z = z * x;
            }
            while ((double)(x) < (double)(0))
            {
                if ((double)(x) > (double)(-0.000000001))
                {
                    result = z / ((1 + 0.5772156649015329 * x) * x);
                    return result;
                }
                z = z / x;
                x = x + 1;
            }
            while ((double)(x) < (double)(2))
            {
                if ((double)(x) < (double)(0.000000001))
                {
                    result = z / ((1 + 0.5772156649015329 * x) * x);
                    return result;
                }
                z = z / x;
                x = x + 1.0;
            }
            if ((double)(x) == (double)(2))
            {
                result = z;
                return result;
            }
            x = x - 2.0;
            pp = 1.60119522476751861407E-4;
            pp = 1.19135147006586384913E-3 + x * pp;
            pp = 1.04213797561761569935E-2 + x * pp;
            pp = 4.76367800457137231464E-2 + x * pp;
            pp = 2.07448227648435975150E-1 + x * pp;
            pp = 4.94214826801497100753E-1 + x * pp;
            pp = 9.99999999999999996796E-1 + x * pp;
            qq = -2.31581873324120129819E-5;
            qq = 5.39605580493303397842E-4 + x * qq;
            qq = -4.45641913851797240494E-3 + x * qq;
            qq = 1.18139785222060435552E-2 + x * qq;
            qq = 3.58236398605498653373E-2 + x * qq;
            qq = -2.34591795718243348568E-1 + x * qq;
            qq = 7.14304917030273074085E-2 + x * qq;
            qq = 1.00000000000000000320 + x * qq;
            result = z * pp / qq;
            return result;
        }


        /*************************************************************************
        Natural logarithm of gamma function

        Input parameters:
            X       -   argument

        Result:
            logarithm of the absolute value of the Gamma(X).

        Output parameters:
            SgnGam  -   sign(Gamma(X))

        Domain:
            0 < X < 2.55e305
            -2.55e305 < X < 0, X is not an integer.

        ACCURACY:
        arithmetic      domain        # trials     peak         rms
           IEEE    0, 3                 28000     5.4e-16     1.1e-16
           IEEE    2.718, 2.556e305     40000     3.5e-16     8.3e-17
        The error criterion was relative when the function magnitude
        was greater than one but absolute when it was less than one.

        The following test used the relative error criterion, though
        at certain points the relative error could be much higher than
        indicated.
           IEEE    -200, -4             10000     4.8e-16     1.3e-16

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1989, 1992, 2000 by Stephen L. Moshier
        Translated to AlgoPascal by Bochkanov Sergey (2005, 2006, 2007).
        *************************************************************************/
        public static double lngamma(double x,
            ref double sgngam)
        {
            double result = 0;
            double a = 0;
            double b = 0;
            double c = 0;
            double p = 0;
            double q = 0;
            double u = 0;
            double w = 0;
            double z = 0;
            int i = 0;
            double logpi = 0;
            double ls2pi = 0;
            double tmp = 0;

            sgngam = 0;

            sgngam = 1;
            logpi = 1.14472988584940017414;
            ls2pi = 0.91893853320467274178;
            if ((double)(x) < (double)(-34.0))
            {
                q = -x;
                w = lngamma(q, ref tmp);
                p = (int)Math.Floor(q);
                i = (int)Math.Round(p);
                if (i % 2 == 0)
                {
                    sgngam = -1;
                }
                else
                {
                    sgngam = 1;
                }
                z = q - p;
                if ((double)(z) > (double)(0.5))
                {
                    p = p + 1;
                    z = p - q;
                }
                z = q * Math.Sin(Math.PI * z);
                result = logpi - Math.Log(z) - w;
                return result;
            }
            if ((double)(x) < (double)(13))
            {
                z = 1;
                p = 0;
                u = x;
                while ((double)(u) >= (double)(3))
                {
                    p = p - 1;
                    u = x + p;
                    z = z * u;
                }
                while ((double)(u) < (double)(2))
                {
                    z = z / u;
                    p = p + 1;
                    u = x + p;
                }
                if ((double)(z) < (double)(0))
                {
                    sgngam = -1;
                    z = -z;
                }
                else
                {
                    sgngam = 1;
                }
                if ((double)(u) == (double)(2))
                {
                    result = Math.Log(z);
                    return result;
                }
                p = p - 2;
                x = x + p;
                b = -1378.25152569120859100;
                b = -38801.6315134637840924 + x * b;
                b = -331612.992738871184744 + x * b;
                b = -1162370.97492762307383 + x * b;
                b = -1721737.00820839662146 + x * b;
                b = -853555.664245765465627 + x * b;
                c = 1;
                c = -351.815701436523470549 + x * c;
                c = -17064.2106651881159223 + x * c;
                c = -220528.590553854454839 + x * c;
                c = -1139334.44367982507207 + x * c;
                c = -2532523.07177582951285 + x * c;
                c = -2018891.41433532773231 + x * c;
                p = x * b / c;
                result = Math.Log(z) + p;
                return result;
            }
            q = (x - 0.5) * Math.Log(x) - x + ls2pi;
            if ((double)(x) > (double)(100000000))
            {
                result = q;
                return result;
            }
            p = 1 / (x * x);
            if ((double)(x) >= (double)(1000.0))
            {
                q = q + ((7.9365079365079365079365 * 0.0001 * p - 2.7777777777777777777778 * 0.001) * p + 0.0833333333333333333333) / x;
            }
            else
            {
                a = 8.11614167470508450300 * 0.0001;
                a = -(5.95061904284301438324 * 0.0001) + p * a;
                a = 7.93650340457716943945 * 0.0001 + p * a;
                a = -(2.77777777730099687205 * 0.001) + p * a;
                a = 8.33333333333331927722 * 0.01 + p * a;
                q = q + a / x;
            }
            result = q;
            return result;
        }


        private static double gammastirf(double x)
        {
            double result = 0;
            double y = 0;
            double w = 0;
            double v = 0;
            double stir = 0;

            w = 1 / x;
            stir = 7.87311395793093628397E-4;
            stir = -2.29549961613378126380E-4 + w * stir;
            stir = -2.68132617805781232825E-3 + w * stir;
            stir = 3.47222221605458667310E-3 + w * stir;
            stir = 8.33333333333482257126E-2 + w * stir;
            w = 1 + w * stir;
            y = Math.Exp(x);
            if ((double)(x) > (double)(143.01608))
            {
                v = Math.Pow(x, 0.5 * x - 0.25);
                y = v * (v / y);
            }
            else
            {
                y = Math.Pow(x, x - 0.5) / y;
            }
            result = 2.50662827463100050242 * y * w;
            return result;
        }


    }

    public class normaldistr
    {
       

        public const double maxrealnumber = 1E300;
        public const double minrealnumber = 1E-300;
        /*************************************************************************
        Error function

        The integral is

                                  x
                                   -
                        2         | |          2
          erf(x)  =  --------     |    exp( - t  ) dt.
                     sqrt(pi)   | |
                                 -
                                  0

        For 0 <= |x| < 1, erf(x) = x * P4(x**2)/Q5(x**2); otherwise
        erf(x) = 1 - erfc(x).


        ACCURACY:

                             Relative error:
        arithmetic   domain     # trials      peak         rms
           IEEE      0,1         30000       3.7e-16     1.0e-16

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/
        public static double errorfunction(double x)
        {
            double result = 0;
            double xsq = 0;
            double s = 0;
            double p = 0;
            double q = 0;

            s = Math.Sign(x);
            x = Math.Abs(x);
            if ((double)(x) < (double)(0.5))
            {
                xsq = x * x;
                p = 0.007547728033418631287834;
                p = 0.288805137207594084924010 + xsq * p;
                p = 14.3383842191748205576712 + xsq * p;
                p = 38.0140318123903008244444 + xsq * p;
                p = 3017.82788536507577809226 + xsq * p;
                p = 7404.07142710151470082064 + xsq * p;
                p = 80437.3630960840172832162 + xsq * p;
                q = 0.0;
                q = 1.00000000000000000000000 + xsq * q;
                q = 38.0190713951939403753468 + xsq * q;
                q = 658.070155459240506326937 + xsq * q;
                q = 6379.60017324428279487120 + xsq * q;
                q = 34216.5257924628539769006 + xsq * q;
                q = 80437.3630960840172826266 + xsq * q;
                result = s * 1.1283791670955125738961589031 * x * p / q;
                return result;
            }
            if ((double)(x) >= (double)(10))
            {
                result = s;
                return result;
            }
            result = s * (1 - errorfunctionc(x));
            return result;
        }


        /*************************************************************************
        Complementary error function

         1 - erf(x) =

                                  inf.
                                    -
                         2         | |          2
          erfc(x)  =  --------     |    exp( - t  ) dt
                      sqrt(pi)   | |
                                  -
                                   x


        For small x, erfc(x) = 1 - erf(x); otherwise rational
        approximations are computed.


        ACCURACY:

                             Relative error:
        arithmetic   domain     # trials      peak         rms
           IEEE      0,26.6417   30000       5.7e-14     1.5e-14

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/
        public static double errorfunctionc(double x)
        {
            double result = 0;
            double p = 0;
            double q = 0;

            if ((double)(x) < (double)(0))
            {
                result = 2 - errorfunctionc(-x);
                return result;
            }
            if ((double)(x) < (double)(0.5))
            {
                result = 1.0 - errorfunction(x);
                return result;
            }
            if ((double)(x) >= (double)(10))
            {
                result = 0;
                return result;
            }
            p = 0.0;
            p = 0.5641877825507397413087057563 + x * p;
            p = 9.675807882987265400604202961 + x * p;
            p = 77.08161730368428609781633646 + x * p;
            p = 368.5196154710010637133875746 + x * p;
            p = 1143.262070703886173606073338 + x * p;
            p = 2320.439590251635247384768711 + x * p;
            p = 2898.0293292167655611275846 + x * p;
            p = 1826.3348842295112592168999 + x * p;
            q = 1.0;
            q = 17.14980943627607849376131193 + x * q;
            q = 137.1255960500622202878443578 + x * q;
            q = 661.7361207107653469211984771 + x * q;
            q = 2094.384367789539593790281779 + x * q;
            q = 4429.612803883682726711528526 + x * q;
            q = 6089.5424232724435504633068 + x * q;
            q = 4958.82756472114071495438422 + x * q;
            q = 1826.3348842295112595576438 + x * q;
            result = Math.Exp(-Math.Pow(x,2)) * p / q;
            return result;
        }


        /*************************************************************************
        Normal distribution function

        Returns the area under the Gaussian probability density
        function, integrated from minus infinity to x:

                                   x
                                    -
                          1        | |          2
           ndtr(x)  = ---------    |    exp( - t /2 ) dt
                      sqrt(2pi)  | |
                                  -
                                 -inf.

                    =  ( 1 + erf(z) ) / 2
                    =  erfc(z) / 2

        where z = x/sqrt(2). Computation is via the functions
        erf and erfc.


        ACCURACY:

                             Relative error:
        arithmetic   domain     # trials      peak         rms
           IEEE     -13,0        30000       3.4e-14     6.7e-15

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/
        public static double normaldistribution(double x)
        {
            double result = 0;

            result = 0.5 * (errorfunction(x / 1.41421356237309504880) + 1);
            return result;
        }


        /*************************************************************************
        Inverse of the error function

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/
        public static double inverf(double e)
        {
            double result = 0;

            result = invnormaldistribution(0.5 * (e + 1)) / Math.Sqrt(2);
            return result;
        }


        /*************************************************************************
        Inverse of Normal distribution function

        Returns the argument, x, for which the area under the
        Gaussian probability density function (integrated from
        minus infinity to x) is equal to y.


        For small arguments 0 < y < exp(-2), the program computes
        z = sqrt( -2.0 * log(y) );  then the approximation is
        x = z - log(z)/z  - (1/z) P(1/z) / Q(1/z).
        There are two rational functions P/Q, one for 0 < y < exp(-32)
        and the other for y up to exp(-2).  For larger arguments,
        w = y - 0.5, and  x/sqrt(2pi) = w + w**3 R(w**2)/S(w**2)).

        ACCURACY:

                             Relative error:
        arithmetic   domain        # trials      peak         rms
           IEEE     0.125, 1        20000       7.2e-16     1.3e-16
           IEEE     3e-308, 0.135   50000       4.6e-16     9.8e-17

        Cephes Math Library Release 2.8:  June, 2000
        Copyright 1984, 1987, 1988, 1992, 2000 by Stephen L. Moshier
        *************************************************************************/
        public static double invnormaldistribution(double y0)
        {
            double result = 0;
            double expm2 = 0;
            double s2pi = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            double y2 = 0;
            double x0 = 0;
            double x1 = 0;
            int code = 0;
            double p0 = 0;
            double q0 = 0;
            double p1 = 0;
            double q1 = 0;
            double p2 = 0;
            double q2 = 0;

            expm2 = 0.13533528323661269189;
            s2pi = 2.50662827463100050242;
            if ((double)(y0) <= (double)(0))
            {
                result = -maxrealnumber;
                return result;
            }
            if ((double)(y0) >= (double)(1))
            {
                result = maxrealnumber;
                return result;
            }
            code = 1;
            y = y0;
            if ((double)(y) > (double)(1.0 - expm2))
            {
                y = 1.0 - y;
                code = 0;
            }
            if ((double)(y) > (double)(expm2))
            {
                y = y - 0.5;
                y2 = y * y;
                p0 = -59.9633501014107895267;
                p0 = 98.0010754185999661536 + y2 * p0;
                p0 = -56.6762857469070293439 + y2 * p0;
                p0 = 13.9312609387279679503 + y2 * p0;
                p0 = -1.23916583867381258016 + y2 * p0;
                q0 = 1;
                q0 = 1.95448858338141759834 + y2 * q0;
                q0 = 4.67627912898881538453 + y2 * q0;
                q0 = 86.3602421390890590575 + y2 * q0;
                q0 = -225.462687854119370527 + y2 * q0;
                q0 = 200.260212380060660359 + y2 * q0;
                q0 = -82.0372256168333339912 + y2 * q0;
                q0 = 15.9056225126211695515 + y2 * q0;
                q0 = -1.18331621121330003142 + y2 * q0;
                x = y + y * y2 * p0 / q0;
                x = x * s2pi;
                result = x;
                return result;
            }
            x = Math.Sqrt(-(2.0 * Math.Log(y)));
            x0 = x - Math.Log(x) / x;
            z = 1.0 / x;
            if ((double)(x) < (double)(8.0))
            {
                p1 = 4.05544892305962419923;
                p1 = 31.5251094599893866154 + z * p1;
                p1 = 57.1628192246421288162 + z * p1;
                p1 = 44.0805073893200834700 + z * p1;
                p1 = 14.6849561928858024014 + z * p1;
                p1 = 2.18663306850790267539 + z * p1;
                p1 = -(1.40256079171354495875 * 0.1) + z * p1;
                p1 = -(3.50424626827848203418 * 0.01) + z * p1;
                p1 = -(8.57456785154685413611 * 0.0001) + z * p1;
                q1 = 1;
                q1 = 15.7799883256466749731 + z * q1;
                q1 = 45.3907635128879210584 + z * q1;
                q1 = 41.3172038254672030440 + z * q1;
                q1 = 15.0425385692907503408 + z * q1;
                q1 = 2.50464946208309415979 + z * q1;
                q1 = -(1.42182922854787788574 * 0.1) + z * q1;
                q1 = -(3.80806407691578277194 * 0.01) + z * q1;
                q1 = -(9.33259480895457427372 * 0.0001) + z * q1;
                x1 = z * p1 / q1;
            }
            else
            {
                p2 = 3.23774891776946035970;
                p2 = 6.91522889068984211695 + z * p2;
                p2 = 3.93881025292474443415 + z * p2;
                p2 = 1.33303460815807542389 + z * p2;
                p2 = 2.01485389549179081538 * 0.1 + z * p2;
                p2 = 1.23716634817820021358 * 0.01 + z * p2;
                p2 = 3.01581553508235416007 * 0.0001 + z * p2;
                p2 = 2.65806974686737550832 * 0.000001 + z * p2;
                p2 = 6.23974539184983293730 * 0.000000001 + z * p2;
                q2 = 1;
                q2 = 6.02427039364742014255 + z * q2;
                q2 = 3.67983563856160859403 + z * q2;
                q2 = 1.37702099489081330271 + z * q2;
                q2 = 2.16236993594496635890 * 0.1 + z * q2;
                q2 = 1.34204006088543189037 * 0.01 + z * q2;
                q2 = 3.28014464682127739104 * 0.0001 + z * q2;
                q2 = 2.89247864745380683936 * 0.000001 + z * q2;
                q2 = 6.79019408009981274425 * 0.000000001 + z * q2;
                x1 = z * p2 / q2;
            }
            x = x0 - x1;
            if (code != 0)
            {
                x = -x;
            }
            result = x;
            return result;
        }

        public static double get_plotn(double x, double disp, double mean)
        {
            return (1 / (Math.Sqrt(2 * Math.PI * disp))) *
                   Math.Exp(
                       -Math.Pow(x - mean, 2) / (2 * disp)
                   );

        }
    }
}
