
using Database_01.Models;
using One.ConsoleApp1.EndPoint;
using One.ConsoleApp1.Models;
using Refit;


var quoteEndpoint = new QuoteEndPoint();
var todoEndPoint = new TodoEndPoint();

var postEndPoint = new PostEndPoint();

RecipesEndPoint recipesEndPoint = new RecipesEndPoint();


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

//var res = await postEndPoint.DeleteAsync(2);
//Console.WriteLine(res.Content);


//var recipes = await recipesEndPoint.GetAllAsync();
//foreach (var recipe in recipes!.recipes)
//{
//    Console.WriteLine($"Recipe Name  ==> {recipe.name} \n");
//}


//var recipe = await recipesEndPoint.GetByIdAsync(1);
//Console.WriteLine($"recipe name => {recipe!.name}");

var recipe = await recipesEndPoint.CreateAsync(new Recipe { name = "Banana Soup" });
Console.WriteLine($"{recipe!.name}");

//var updateRecipe = await recipesEndPoint.UpdateAsync(2, new Recipe { name = "Orange Juice"});
//Console.WriteLine($"Update Recipe ==> {updateRecipe?.name}");


//var deleteResult = await recipesEndPoint.DeleteAsync(1);
//Console.WriteLine($"{deleteResult!.name}");


//GameEndPoint gameEndPoint = new GameEndPoint();

//var games = await gameEndPoint.GetGamesAsync();
//foreach (var game in games!)
//{
//    Console.WriteLine($"{game.GameId} :: game name ==> {game.Name}");
//}


//try
//{
//    var g = await gameEndPoint.GetGameAsync(888);
//    Console.WriteLine($"game name is {g.Name}");
//}
//catch (ApiException err)
//{
//    Console.WriteLine(err.Message);
//}

//var newGame = await gameEndPoint.CreateGameAsync(new Game { Name = "Harvest Moon",Genre = "Farming",Price = 7000});
//Console.WriteLine($" new game name is {newGame?.Name}");