using System;
namespace Solucion_Lab_21_abril
{
    public class User
    {
        public User()
        {
        }

        private void OnEmailSent()
        {
            String verifyEmailYN;
            Console.Write("Desea verificar su correo?  {Y/N}");
            verifyEmailYN = Console.ReadLine();
            return;
        }

    }
}
