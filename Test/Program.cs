// See https://aka.ms/new-console-template for more information
using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Microsoft.EntityFrameworkCore;

Context context = new Context();

ICRUD<Post> crud = new CRUD<Post>(context);

Post p = crud.Get(2);

p.title = "---------Titulo Actualizdo";
p.userid = 2;
p.body = "----------Cuerpo del post Actualizado";

crud.Update(p);
//crud.Add(p);


/*
Post p = new Post();

p.title = "Titulo insertado";
p.userid = 2;
p.body = "Cuerpo del post insertado";

crud.Add(p);
*/





IEnumerable<Post> pa = crud.All();

Console.WriteLine("Hello, World!");