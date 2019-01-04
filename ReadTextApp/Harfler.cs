using System;

namespace ReadTextApp
{
    public static class Harfler
    {
        const int CokYakinHassasiyeti = 2;
        static bool CokYakin(int a, int b)
        {
            return Math.Abs(a - b) <= CokYakinHassasiyeti;
        }

        public static char GetChar(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            if (Char_A(ust, sag, alt, sol))
                return 'A';
            if (Char_B(ust, sag, alt, sol))
                return 'B';
            if (Char_C(ust, sag, alt, sol))
                return 'C';
            if (Char_D(ust, sag, alt, sol))
                return 'D';
            if (Char_E(ust, sag, alt, sol))
                return 'E';
            if (Char_F(ust, sag, alt, sol))
                return 'F';
            if (Char_G(ust, sag, alt, sol))
                return 'G';
            if (Char_H(ust, sag, alt, sol))
                return 'H';
            if (Char_I(ust, sag, alt, sol))
                return 'I';
            if (Char_J(ust, sag, alt, sol))
                return 'J';
            if (Char_M(ust, sag, alt, sol))
                return 'M';

            return '_';
        }

        static bool Char_A(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                sol.a1 > sol.a2 &&
                sol.a2 > sol.a3 &&
                sol.a3 > sol.a4 &&
                sol.a4 > sol.a5 &&

                sag.a1 > sag.a2 &&
                sag.a2 > sag.a3 &&
                sag.a3 > sag.a4 &&
                sag.a4 > sag.a5 &&

                ust.a3 < ust.a2 &&
                ust.a3 < ust.a4 &&
                ust.a4 < ust.a5 &&
                ust.a2 < ust.a1 &&

                alt.a1 < alt.a2 &&
                alt.a1 < alt.a3 &&
                alt.a1 < alt.a4 &&
                alt.a5 < alt.a2 &&
                alt.a5 < alt.a3 &&
                alt.a5 < alt.a4 &&

                true;
        }

        static bool Char_B(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                sag.a1 > sag.a2 &&
                sag.a3 > sag.a2 &&
                sag.a3 > sag.a4 &&
                sag.a5 > sag.a4 &&

                CokYakin(ust.a1, ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                ust.a5 > ust.a2 &&
                ust.a5 > ust.a3 &&

                CokYakin(alt.a1, alt.a2) &&
                CokYakin(alt.a2, alt.a3) &&
                alt.a5 > alt.a2 &&
                alt.a5 > alt.a3 &&
                true;
        }

        static bool Char_C(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                sol.a1 > sol.a2 &&
                sol.a2 > sol.a3 &&
                sol.a3 < sol.a4 &&
                sol.a4 < sol.a5 &&

                sag.a1 < sag.a2 &&
                sag.a1 < sag.a3 &&
                sag.a1 < sag.a4 &&
                sag.a5 < sag.a2 &&
                sag.a5 < sag.a3 &&
                sag.a5 < sag.a4 &&

                ust.a1 > ust.a2 &&
                ust.a2 > ust.a3 &&
                ust.a5 > ust.a3 &&

                alt.a1 > alt.a2 &&
                alt.a1 > alt.a3 &&
                alt.a5 > alt.a3 &&
                true;
        }

        static bool Char_H(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                CokYakin(sag.a1, sag.a2) &&
                CokYakin(sag.a2, sag.a3) &&
                CokYakin(sag.a3, sag.a4) &&
                CokYakin(sag.a4, sag.a5) &&

                (ust.a1 < ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                CokYakin(ust.a3, ust.a4) &&
                (ust.a4 > ust.a5) &&

                (alt.a1 < alt.a2) &&
                CokYakin(alt.a2, alt.a3) &&
                CokYakin(alt.a3, alt.a4) &&
                (alt.a4 > alt.a5) &&

                true;
        }

        static bool Char_I(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                CokYakin(sag.a1, sag.a2) &&
                CokYakin(sag.a2, sag.a3) &&
                CokYakin(sag.a3, sag.a4) &&
                CokYakin(sag.a4, sag.a5) &&

                CokYakin(ust.a1, ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                CokYakin(ust.a3, ust.a4) &&
                CokYakin(ust.a4, ust.a5) &&

                CokYakin(alt.a1, alt.a2) &&
                CokYakin(alt.a2, alt.a3) &&
                CokYakin(alt.a3, alt.a4) &&
                CokYakin(alt.a4, alt.a5) &&

                true;
        }

        static bool Char_D(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                (sag.a1 > sag.a2) &&
                (sag.a1 > sag.a3) &&
                (sag.a5 > sag.a3) &&
                (sag.a5 > sag.a4) &&

                CokYakin(ust.a1, ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                (ust.a4 > ust.a3) &&
                (ust.a5 > ust.a4) &&

                CokYakin(alt.a1, alt.a2) &&
                CokYakin(alt.a2, alt.a3) &&
                (alt.a5 > alt.a3) &&
                (alt.a5 > alt.a4) &&

                true;
        }

        static bool Char_E(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                (sag.a2 > sag.a1) &&
                (sag.a4 > sag.a5) &&

                CokYakin(ust.a1, ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                CokYakin(ust.a3, ust.a4) &&

                CokYakin(alt.a1, alt.a2) &&
                CokYakin(alt.a2, alt.a3) &&
                CokYakin(alt.a3, alt.a4) &&

                true;
        }

        static bool Char_F(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                (sag.a2 > sag.a1) &&
                (sag.a4 > sag.a1) &&
                CokYakin(sag.a4, sag.a5) &&

                CokYakin(ust.a1, ust.a2) &&
                CokYakin(ust.a2, ust.a3) &&
                CokYakin(ust.a3, ust.a4) &&
                CokYakin(ust.a4, ust.a5) &&

                (alt.a3 > alt.a1) &&
                CokYakin(alt.a3, alt.a4) &&

                true;
        }

        static bool Char_G(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                (sol.a1 > sol.a2) &&
                (sol.a2 > sol.a3) &&
                (sol.a5 > sol.a4) &&
                
                CokYakin(sag.a3, sag.a4) &&
                (sag.a5 > sag.a4) &&

                (ust.a1 > ust.a2) &&
                (ust.a2 > ust.a3) &&
                (ust.a5 > ust.a4) &&

                (alt.a1 > alt.a2) &&
                (alt.a2 > alt.a3) &&
                (alt.a5 > alt.a4) &&

                true;
        }

        static bool Char_J(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                (sol.a5 > sol.a3) &&

                CokYakin(sag.a1, sag.a2) &&
                CokYakin(sag.a2, sag.a3) &&
                CokYakin(sag.a3, sag.a4) &&
                (sag.a5 > sag.a4) &&

                (ust.a1 > ust.a5) &&
                (ust.a2 > ust.a5) &&

                (alt.a1 > alt.a2) &&
                (alt.a5 > alt.a4) &&

                true;
        }

        static bool Char_M(Bosluk ust, Bosluk sag, Bosluk alt, Bosluk sol)
        {
            return
                CokYakin(sol.a1, sol.a2) &&
                CokYakin(sol.a2, sol.a3) &&
                CokYakin(sol.a3, sol.a4) &&
                CokYakin(sol.a4, sol.a5) &&

                CokYakin(sag.a1, sag.a2) &&
                CokYakin(sag.a2, sag.a3) &&
                CokYakin(sag.a3, sag.a4) &&
                CokYakin(sag.a4, sag.a5) &&

                (ust.a2 > ust.a1) &&
                (ust.a3 > ust.a2) &&
                (ust.a3 > ust.a2) &&
                (ust.a4 > ust.a5) &&

                (alt.a2 > alt.a1) &&
                (alt.a2 > alt.a3) &&
                (alt.a4 > alt.a3) &&
                (alt.a4 > alt.a5) &&

                true;
        }




    }
}
