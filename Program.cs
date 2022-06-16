//variables declaration
var carRangeHours = 13;
double carsAverage = 0;
double lambda = 10;
double timeBetweenArrivals = 0;
var numberOfServices = 0;
var mu = 0;
double p = 0;
double L = 0;
double Lq = 0;
double W = 0;
double Wq = 0;

var numberOfTest = 1;


Console.WriteLine("<--------Aplicación del modelo M/M/1--------->\n");
Console.WriteLine("Determinación de cantidad de vehículos que pasan entre al CATIE y tamaño de colas entre las 6am y 6pm");
Console.WriteLine("****Simulación con valores iniciales****\n");
showQueueStadistics();

var userResp = "s";
do
{
    Console.WriteLine("+++++ ¿Desea realizar otra simulación? s/n");
    userResp = Console.ReadLine();
    if(userResp == "s")
    {
        Console.WriteLine("Digite una nueva tasa de llegadas (lambda)");
        var newLambda= Console.ReadLine();
        if (!Double.TryParse(newLambda, out lambda)){
            Console.WriteLine("No se ha ingresado un valor válido para Lambda");
        }
        else
        {
            showQueueStadistics();
        }
    }
} while (userResp=="s");


void onLoadValues()
{
    carsAverage = (double) 600;
    timeBetweenArrivals = (double)(1 / carsAverage);
    numberOfServices = 1;
    mu = 60/4;
    p = (double) (lambda / mu);
    L = (double)(p / (1 - p));
    Lq = (double)(Math.Pow(p,2)/(1-p));
    W = (double)(1 / (mu * (1 - p)));
    Wq = (double)(p / (mu * (1 - p)));
}

void showPValues()
{
    var p0 = 1 - p;
    var pValues = new double[carRangeHours];
    pValues[0] = p0;
    Console.WriteLine("***Mostrando valores p de probabilidad p0,p1,p2...n ***\n");
    for (int i = 1; i < carRangeHours; i++)
    {
        Console.Write("p"+(i-1)+"= " + pValues[i - 1]+"\n");
        pValues[i] = pValues[i-1] * p;
    }
}

void showQueueStadistics()
{
    onLoadValues();
    Console.WriteLine("---SIMULACIÓN #" + numberOfTest++ +"\n");
    Console.WriteLine("La tasa de llegadas de carros es de " + lambda + " por minuto(lambda)\n");
    Console.WriteLine("y su tiempo medio entre llegadas es de " + timeBetweenArrivals+"\n");
    Console.WriteLine("Se atienden "+mu+ " carros por minuto(µ)\n");
    Console.WriteLine("La intensidad del tráfico es de "+p+"(p)\n");
    if (p < 1)
    {
        Console.WriteLine("***La carretera o el sistema está actualmente estable ya que se tiene que el tráfico es menor a 1, es decir, " + p+" ***\n");
    }
    Console.WriteLine("Los carros esperan "+L+" minutos en la carretera(L)\n");
    Console.WriteLine("Los carros esperan "+Lq+" minutos en la cola(Lq)\n");
    Console.WriteLine("Se debe esperar una media de "+W+" minutos en la carretera(W)");
    Console.WriteLine("Se debe esperar una media de "+Wq+" minutos en la cola(Wq)\n");

    showPValues();

    Console.WriteLine("\n");
}