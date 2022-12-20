using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Entities._Interface;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    [TestClass]
    public class CRUDTest
    {

        private IContext _context;
        private ICRUD<User> CUser;
        private ICRUD<Client> CClient;
        private ICRUD<Provider> CProvider;
        private ICRUD<Product> CProduct;

        User _user;
        Provider _provider;
        Client _clien;
        Product _product;

        [TestInitialize]
        public void init() {
            _context = new Contest();
            Assert.IsNotNull(_context, "Error en inicializacion de contexto de prueba");

            CUser       = new CRUD<User>(_context);
            CClient     = new CRUD<Client>(_context);
            CProvider   = new CRUD<Provider>(_context);
            CProduct    = new CRUD<Product>(_context);

        /*CProspecto = new CRUD<Prospecto>(_context);
        CVacante = new CRUD<Vacante>(_context);
        CEntrevista = new CRUD<Entrevista>(_context);

        _prospecto = new Prospecto();
        _prospecto.id = new Random().Next();
        _prospecto.nombre = "testNombre";
        _prospecto.correo = "test@test.com";
        _prospecto.fecha_registro = DateTime.Now;*/
    }
        [TestMethod]
        public void test_delete() {
            Assert.IsTrue(CUser.Delete(1));
            Assert.IsTrue(CClient.Delete(1));
            Assert.IsTrue(CProvider.Delete(1));
            Assert.IsTrue(CProduct.Delete(1));
        }

        [TestMethod]
        public void Test_Add()
        {
            User user = new User();

            Assert.ThrowsException<DbUpdateException>(() => CUser.Add(user));
            user.username = "UserName_Test";
            user.email = "user@test.com";
            //Empty Password Validation
            Assert.ThrowsException<DbUpdateException>(() => CUser.Add(user),"password");
            user.password = "passwordtest";
            CUser.Add(user);
            Assert.IsTrue(user.id != 0 );
        }
        [TestMethod]
        public void Test_Get()
        {
        }

    }
}