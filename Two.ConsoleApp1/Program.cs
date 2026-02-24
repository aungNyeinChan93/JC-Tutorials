


using Two.ConsoleApp1.EndPoints;
using Two.ConsoleApp1.Models;

BlogEndPoint blogEndPoint = new BlogEndPoint();

//var blogs = await blogEndPoint.GetAllAsync();

//foreach (var blog in blogs!)
//{
//    Console.WriteLine($"blog Title ==> {blog.Title} and {blog.BlogId} \n");
//}

//var blog = await blogEndPoint.GetOneAsync(93);
//Console.WriteLine(blog!.Title);


//var newBlog = await blogEndPoint.CreateAsync(new Database_02.Models.TblBlog { AuthorName ="chan",Title = "Test Title",Description = "test desc"});
//Console.WriteLine($"{newBlog?.Title}");

//var updateBlog = await blogEndPoint.UpdateAsync(93,new Database_02.Models.TblBlog { AuthorName = "cahn chan", Title = "Test Title", Description = "test desc" });
//Console.WriteLine($"{updateBlog?.AuthorName}");

//await blogEndPoint.DeleteAsync(93);

PostEndPoint postEndPoint = new PostEndPoint();

//var res = await postEndPoint.GetAllPostsAsync();
//foreach (var post in res.posts)
//{
//    Console.WriteLine($"post title ==> {post.title} \n");
//}


//var post = await postEndPoint.GetOnePostAsync(1);
//Console.WriteLine($"post title ==> {post!.title}");

//var p = await postEndPoint.CreatePostAsync(new Two.ConsoleApp1.Models.Post { body = "tes boffyfyf",title="test"});
//Console.WriteLine($"Body ==>{p!.title}");

UserEndPoint userEndPoint = new UserEndPoint();

//var res = await userEndPoint.GetUsersAsync();
//foreach (var user in res!.users)
//{
//    Console.WriteLine($"user name is {user?.firstName} \n");
//}

//var user = await userEndPoint.GetUserAsync(1);
//Console.WriteLine($"user name is {user?.firstName}");

//var createUser = await userEndPoint.CreateUserAsync(new User { firstName="chan" ,lastName = "chan",age = 34});
//Console.WriteLine($"user name is {createUser!.firstName}");

//var updateUser = await userEndPoint.UpdateUserAsync(1,new User { lastName = "owen"});
//Console.WriteLine($"user name is {updateUser?.lastName}");

var deleteUser = await userEndPoint.DeleteUserAsync(1);
Console.WriteLine(deleteUser?.lastName);