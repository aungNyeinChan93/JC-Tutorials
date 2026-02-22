
using One.ConsoleApp1.EndPoint;
using One.ConsoleApp1.Models;


var quoteEndpoint = new QuoteEndPoint();
var todoEndPoint = new TodoEndPoint();


//await quoteEndpoint.ReadAsync();
//await quoteEndpoint.GetOneAsync(3);

//Console.WriteLine("-----------");

//var newQuote = new Quote() { author ="chan", quote = "Dont stop for false!"};

//await quoteEndpoint.CreateAsync(newQuote);


var result = await todoEndPoint.ReadAllAsync();
foreach (var todo in result?.todos!)
{
    Console.WriteLine($"Todo ->> {todo.todo}");
}

//var todo = await todoEndPoint.GetOneAsync(5);
//Console.WriteLine($"Todo - {todo!.todo}");


//await todoEndPoint.CreateAsync(new Todo { todo = "Run for health", completed = false,userId = 152 });

//await todoEndPoint.UpdateAsync( 2,new Todo { completed = true  ,id = 2 ,userId = 33,todo= "ydfasdf"});


//await todoEndPoint.DeleteAsync(id:1);