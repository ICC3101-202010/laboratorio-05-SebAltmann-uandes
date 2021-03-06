﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Solucion_Lab_21_abril
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos todos los objetos necesarios
            DataBase database = new DataBase();
            Server server = new Server(database);
            MailSender mailSender = new MailSender();
            SMSSender smsSender = new SMSSender();
            User user = new User();

            //Suscribir los que escuchan los eventos
            // Notar que para poder realizar las suscripciones es necesario tener instancias de las clases, y que los parametros
            // del evento y del metodo que se le suscribe deben ser igual (object y eventargs)
            //1- Suscribir OnRegistrado de mailSender para que escuche el evento Registrado enviado por servidor
            server.Registered += mailSender.OnRegistered;
            //2- Suscribir OnCambiadaContrasena de mailSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += mailSender.OnPasswordChanged;
            //3- Suscribir OnCambiadaContrasena de smsSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += smsSender.OnPasswordChanged;


            // Controla la ejecucion mientras el usuario no quiera salir
            bool exec = true;
            while (exec)
            {
                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() { "Registrarse", "Cambiar contrasena", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();
                        server.Register();
                        break;
                    case "Cambiar contrasena":
                        Console.Clear();
                        server.ChangePassword();
                        break;
                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        // Metodo para mostrar las opciones posibles
        private static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];
        }
    }
}
