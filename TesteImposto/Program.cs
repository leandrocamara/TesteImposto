using System;
using System.Windows.Forms;
using Imposto.IoC;
using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace TesteImposto
{
    internal static class Program
    {
        private static Container _container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrap();

            Application.Run(_container.GetInstance<FormImposto>());
        }

        private static void Bootstrap()
        {
            _container = new Container();

            AutoRegisterWindowsForms(_container);

            Bootstrapper.AddBootstrapperIoC(_container);
        }

        private static void AutoRegisterWindowsForms(Container container)
        {
            var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

            foreach (var type in types)
            {
                var registration = Lifestyle.Transient.CreateRegistration(type, container);

                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "Forms should be disposed by app code; not by the container.");

                container.AddRegistration(type, registration);
            }
        }
    }
}