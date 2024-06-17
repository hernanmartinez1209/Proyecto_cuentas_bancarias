using Microsoft.Win32.SafeHandles;

Dictionary<string, string> usuarios = new Dictionary<string, string>();
Dictionary<int, double> cuentas = new Dictionary<int, double>();
string adminName = "administrator";
string adminPass = "admin";
 while (true)
 {
     Console.Clear();
    Console.WriteLine("-------------------------------");
    Console.WriteLine("Bienvenido Al Cajero Automatico Del Banco T1474");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("Va a iniciar Secion con Usuario Normal o Administrador:");
    Console.WriteLine("-------------------------------");
    Console.Write("Su usuario es administrador o Usuario normal :");
     string userNameAdmin = Console.ReadLine();

    if (adminName == userNameAdmin)
   {
        while (true)
{
    Console.Clear();
    Console.WriteLine("-------------------------------");
    Console.WriteLine("Menú de Registro e Inicio de Sesión");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("1. Registrar usuario");
    Console.WriteLine("2. Iniciar sesión");
    Console.WriteLine("3. Dar de baja un usuario");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");
    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            RegistrarUsuario();
            break;
        case 2:
        
                        if (usuarios.Count == 0)
                {
                    Console.WriteLine("No hay usuarios registrados. Intente de nuevo.");
                    Console.ReadKey();
                    break;
                }

            IniciarSesion();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Menú de Cuentas Bancarias");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Agregar cuenta");
                Console.WriteLine("2. Dar de baja una cuenta");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Retirar");
                Console.WriteLine("5. Verificar saldo");
                Console.WriteLine("6. Salir al menú principal");
                Console.Write("Seleccione una opción: ");
                int opcionCuenta = Convert.ToInt32(Console.ReadLine());

                switch (opcionCuenta)
                {
                    case 1:
                        AgregarCuenta();
                        break;
                    case 2:
                        DarDeBajaCuenta();
                        break;
                    case 3:
                        Depositar();
                        break;
                    case 4:
                        Retirar();
                        break;
                    case 5:
                        VerificarSaldo();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                }

                if (opcionCuenta == 6)
                {
                    break;
                }
            }
            break;
        case 3:
            DarDeBajaUsuario();
            break;
        case 4:
            Console.WriteLine("Adiós!");
            return;
        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            Console.ReadKey();
            break;
    } 
}


  }
 }

void RegistrarUsuario()
{ 
    
    Console.Write("Ingrese el nombre de usuario completo: ");
    string userName = Console.ReadLine();

    // Console.Write("Ingrese el ID: ");
    // string userID = Console.ReadLine();

    // Console.Write("Ingrese Telefono Mobile: ");
    // string userTelefono = Console.ReadLine();

    // Console.Write("Ingrese Correo Electronico: ");
    // string Email = Console.ReadLine();

    // Console.Write("Ingrese el nombre de usuario: ");
    // string userNickName = Console.ReadLine();

    Console.Write("Ingrese la contraseña: ");
    string password = Console.ReadLine();

    // Console.Write("Ingrese de Nacimiento");
    // string fechaUserCumple = Console.ReadLine();

    // Console.Write("Fecha de creacion del Usuario");
    // string fechaAddUser = Console.ReadLine();

    if (usuarios.ContainsKey(userName))
    {
        Console.WriteLine("El usuario ya existe. Intente de nuevo.");
        Console.ReadKey();
        return;
    }

    usuarios.Add(userName, password);
    Console.WriteLine("Usuario registrado con éxito!");
    Console.ReadKey();
}

void IniciarSesion()
{
    Console.Write("Ingrese el nombre de usuario: ");
    string userName = Console.ReadLine();
    Console.Write("Ingrese la contraseña: ");
    string password = Console.ReadLine();

    if (usuarios.ContainsKey(userName) && usuarios[userName] == password)
    {
        Console.WriteLine("Inicio de sesión exitoso!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Credenciales incorrectas. Intente de nuevo.");
        Console.ReadKey();
    }
}

void DarDeBajaUsuario()
{
    Console.Write("Ingrese el nombre de usuario que desea dar de baja: ");
    string userName = Console.ReadLine();

    if (usuarios.ContainsKey(userName))
    {
        usuarios.Remove(userName);
        Console.WriteLine("Usuario dado de baja con éxito!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("El usuario no existe. Intente de nuevo.");
        Console.ReadKey();
    }
}

void AgregarCuenta()
{
    Console.Write("Ingrese el número de cuenta: ");
    int numeroCuenta = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingrese el saldo inicial: ");
    double saldoInicial = Convert.ToDouble(Console.ReadLine());

    if (cuentas.ContainsKey(numeroCuenta))
    {
        Console.WriteLine("La cuenta ya existe. Intente de nuevo.");
        Console.ReadKey();
        return;
    }

    cuentas.Add(numeroCuenta, saldoInicial);
    Console.WriteLine("Cuenta agregada con éxito!");
    Console.ReadKey();
}

void DarDeBajaCuenta()
{
    Console.Write("Ingrese el número de cuenta que desea dar de baja: ");
    int numeroCuenta = Convert.ToInt32(Console.ReadLine());

    if (cuentas.ContainsKey(numeroCuenta))
    {
        cuentas.Remove(numeroCuenta);
        Console.WriteLine("Cuenta dada de baja con éxito!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("La cuenta no existe. Intente de nuevo.");
        Console.ReadKey();
    }
}

void Depositar()
{
    Console.Write("Ingrese el número de cuenta: ");
    int numeroCuenta = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingrese el monto a depositar: ");
    double monto = Convert.ToDouble(Console.ReadLine());

    if (cuentas.ContainsKey(numeroCuenta))
    {
        cuentas[numeroCuenta] += monto;
        Console.WriteLine();

        Console.WriteLine("Depósito realizado con éxito!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("La cuenta no existe. Intente de nuevo.");
        Console.ReadKey();
    }
}

void Retirar()
{
    Console.Write("Ingrese el número de cuenta: ");
    int numeroCuenta = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingrese el monto a retirar: ");
    double monto = Convert.ToDouble(Console.ReadLine());

    if (cuentas.ContainsKey(numeroCuenta))
    {
        if (cuentas[numeroCuenta] >= monto)
        {
            cuentas[numeroCuenta] -= monto;
            Console.WriteLine("Retiro realizado con éxito!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Saldo insuficiente. Intente de nuevo.");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("La cuenta no existe. Intente de nuevo.");
        Console.ReadKey();
    }
}

void VerificarSaldo()
{
    Console.Write("Ingrese el número de cuenta: ");
    int numeroCuenta = Convert.ToInt32(Console.ReadLine());

    if (cuentas.ContainsKey(numeroCuenta))
    {
        Console.WriteLine("Saldo actual: " + cuentas[numeroCuenta]);
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("La cuenta no existe. Intente de nuevo.");
        Console.ReadKey();
    }
}
