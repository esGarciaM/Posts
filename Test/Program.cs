// See https://aka.ms/new-console-template for more information
using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Entities._Interface;
using Microsoft.EntityFrameworkCore;





 void test1()
{
    Console.WriteLine("test1 OK!");
}

void test2()
{
    Console.WriteLine("test2 OK!");
}

void test3()
{
    Console.WriteLine("test3 OK!");
}

Dictionary<int, Action> d = new Dictionary<int, Action>() {
    { 1,()=> test1()},
    { 2,()=> test2()},
    { 3,()=> test3()}
};

d[1]();
d[2]();
d[3]();

return;
IContext context = new Contest();

ICRUD<Entrevista> centrevista = new CRUD<Entrevista>(context);
ICRUD<Prospecto> cprospecto = new CRUD<Prospecto>(context);
ICRUD<Vacante> cvacante= new CRUD<Vacante>(context);


Prospecto p = new Prospecto();
/*
p.id = 1;
//cprospecto.Add(p);

p.nombre = "updated";
p.correo = "updated";

cprospecto.Update(p);

cprospecto.Delete(1);*/

var data = cprospecto.Where("truncate table PROSPECTO");

/*
Vacante v = new Vacante();
v.id = 1;
v.activo = true;
v.area = "test";
v.sueldo = 5.2;

cvacante.Add(v);*/



/*
var a = centrevista.Get(1);
var b = cprospecto.Get(1); ;
var c = cvacante.Get(1);
string x= "asd";*/



/*
Post p = crud.Get(2);

p.title = "---------Titulo Actualizdo_______________________________________________";
Console.WriteLine(p.title);
p.userid = 2;
p.body = "----------Cuerpo del post Actualizado";

crud.Update(p);*/
Prospecto px = new Prospecto();


//crud.Add(px);


//crud.Add(p);


/*
Post p = new Post();

p.title = "Titulo insertado";
p.userid = 2;
p.body = "Cuerpo del post insertado";

crud.Add(p);
*/





//IEnumerable<Post> pa = crud.All();

Console.WriteLine("Hello, World!");