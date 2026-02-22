
using One.ConsoleApp1.EndPoint;
using One.ConsoleApp1.Models;


var quoteEndpoint = new QuoteEndPoint();
var todoEndPoint = new TodoEndPoint();

var postEndPoint = new PostEndPoint();


//await quoteEndpoint.ReadAsync();
//await quoteEndpoint.GetOneAsync(3);

//Console.WriteLine("-----------");

//var newQuote = new Quote() { author ="chan", quote = "Dont stop for false!"};

//await quoteEndpoint.CreateAsync(newQuote);


//var result = await todoEndPoint.ReadAllAsync();
//foreach (var todo in result?.todos!)
//{
//    Console.WriteLine($"Todo ->> {todo.todo}");
//}

//var todo = await todoEndPoint.GetOneAsync(5);
//Console.WriteLine($"Todo - {todo!.todo}");


//await todoEndPoint.CreateAsync(new Todo { todo = "Run for health", completed = false,userId = 152 });

//await todoEndPoint.UpdateAsync( 2,new Todo { completed = true  ,id = 2 ,userId = 33,todo= "ydfasdf"});


//await todoEndPoint.DeleteAsync(id:1);



//var result = await postEndPoint.GetAll();

//foreach (var post in result!.posts)
//{
//    Console.WriteLine($"Post title =>> {post.title} \n");
//}

//var p = await postEndPoint.GetOneAsync(1);
//Console.WriteLine($"Body -->{p!.body}");


//var newPost = await postEndPoint.CreateAsync(new Post { body = "test body", title = "test title", userId = 15 });
//Console.WriteLine($"new post title ==> {newPost!.title}");


//await postEndPoint.UpdateAsync(2, new Post { title = "change title" ,id = 2});

var res = await postEndPoint.DeleteAsync(2);
Console.WriteLine(res.Content);
