using QJB.Dapper.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QJB.Dapper
{
    public class DapperTest
    {
        #region DTOClasses
        [Table("Users")]
        public class UserEditableSettings
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        //For .Net 4.5> [System.ComponentModel.DataAnnotations.Schema.Table("Users")]  or the attribute built into SimpleCRUD
        [Table("Users")]
        public class User : UserEditableSettings
        {
            //we modified so enums were automatically handled, we should also automatically handle nullable enums
            public DayOfWeek? ScheduledDayOff { get; set; }

            [ReadOnly(true)]
            public DateTime CreatedDate { get; set; }

            [NotMapped]
            public int NotMappedInt { get; set; }
        }

        [Table("Users")]
        public class User1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int? ScheduledDayOff { get; set; }
        }

        public class Car
        {
            #region DatabaseFields
            //System.ComponentModel.DataAnnotations.Key
            [Key]
            public int CarId { get; set; }
            public int? Id { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            #endregion

            #region RelatedTables
            public List<User> Users { get; set; }
            #endregion

            #region AdditionalFields
            [Editable(false)]
            public string MakeWithModel { get { return Make + " (" + Model + ")"; } }
            #endregion

        }

        public class BigCar
        {
            #region DatabaseFields
            //System.ComponentModel.DataAnnotations.Key
            [Key]
            public long CarId { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            #endregion

        }

        [Table("CarLog", Schema = "Log")]
        public class CarLog
        {
            public int Id { get; set; }
            public string LogNotes { get; set; }
        }

        /// <summary>
        /// This class should be used for failing tests, since no schema is specified and 'CarLog' is not on dbo
        /// </summary>
        [Table("CarLog")]
        public class SchemalessCarLog
        {
            public int Id { get; set; }
            public string LogNotes { get; set; }
        }

        public class City
        {
            [Key]
            public string Name { get; set; }
            public int Population { get; set; }
        }

        public class GUIDTest
        {
            [Key]
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class StrangeColumnNames
        {
            [Key]
            [Column("ItemId")]
            public int Id { get; set; }
            public string Word { get; set; }
            [Column("colstringstrangeword")]
            public string StrangeWord { get; set; }
            [Column("KeywordedProperty")]
            public string Select { get; set; }
            [Editable(false)]
            public string ExtraProperty { get; set; }
        }

        public class IgnoreColumns
        {
            [Key]
            public int Id { get; set; }
            [IgnoreInsert]
            public string IgnoreInsert { get; set; }
            [IgnoreUpdate]
            public string IgnoreUpdate { get; set; }
            [IgnoreSelect]
            public string IgnoreSelect { get; set; }
            [IgnoreInsert]
            [IgnoreUpdate]
            [IgnoreSelect]
            public string IgnoreAll { get; set; }
        }

        public class UserWithoutAutoIdentity
        {
            [Key]
            [Required]
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class KeyMaster
        {
            [Key, Required]
            public int Key1 { get; set; }
            [Key, Required]
            public int Key2 { get; set; }
        }

        #endregion

        public class Tests
        {
            public Tests(DataBase.Dialect dbtype)
            {
                _dbtype = dbtype;
            }
            private DataBase.Dialect _dbtype;

            private IDbConnection GetOpenConnection()
            {
                IDbConnection connection;
                connection = new SqlConnection(@"Data Source = .\sqlexpress;Initial Catalog=DapperSimpleCrudTestDb;Integrated Security=True;MultipleActiveResultSets=true;");
                DataBase.SetDialect(DataBase.Dialect.SQLServer);
                connection.Open();
                return connection;
            }

            //basic tests
            public void TestInsertWithSpecifiedTableName()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestInsertWithSpecifiedTableName", Age = 10 });
                    var user = connection.Get<User>(id);
                    connection.Delete<User>(id);

                }
            }

            public void TestInsertUsingBigIntPrimaryKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert<long, BigCar>(new BigCar { Make = "Big", Model = "Car" });
                    connection.Delete<BigCar>(id);

                }
            }

            public void TestInsertUsingGenericLimitedFields()
            {
                using (var connection = GetOpenConnection())
                {
                    //arrange
                    var user = new User { Name = "User1", Age = 10, ScheduledDayOff = DayOfWeek.Friday };

                    //act
                    var id = connection.Insert<int?, UserEditableSettings>(user);

                    //assert
                    var insertedUser = connection.Get<User>(id);
                    //insertedUser.ScheduledDayOff.IsNull();

                    connection.Delete<User>(id);
                }
            }

            public void TestSimpleGet()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "UserTestSimpleGet", Age = 10 });
                    var user = connection.Get<User>(id);
                    //user.Name.IsEqualTo("UserTestSimpleGet");
                    connection.Delete<User>(id);

                }
            }

            public void TestDeleteById()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "UserTestDeleteById", Age = 10 });
                    connection.Delete<User>(id);
                    //connection.Get<User>(id).IsNull();
                }
            }

            public void TestDeleteByObject()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestDeleteByObject", Age = 10 });
                    var user = connection.Get<User>(id);
                    connection.Delete(user);
                    //connection.Get<User>(id).IsNull();
                }
            }

            public void TestSimpleGetList()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestSimpleGetList1", Age = 10 });
                    connection.Insert(new User { Name = "TestSimpleGetList2", Age = 10 });
                    var user = connection.GetList<User>(new { });
                    //user.Count().IsEqualTo(2);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestFilteredGetList()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestFilteredGetList1", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredGetList2", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredGetList3", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredGetList4", Age = 11 });

                    var user = connection.GetList<User>(new { Age = 10 });
                    //user.Count().IsEqualTo(3);
                    //connection.Execute("Delete from Users");
                }
            }


            public void TestFilteredGetListWithMultipleKeys()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new KeyMaster { Key1 = 1, Key2 = 1 });
                    connection.Insert(new KeyMaster { Key1 = 1, Key2 = 2 });
                    connection.Insert(new KeyMaster { Key1 = 1, Key2 = 3 });
                    connection.Insert(new KeyMaster { Key1 = 2, Key2 = 4 });

                    var keyMasters = connection.GetList<KeyMaster>(new { Key1 = 1 });
                    //keyMasters.Count().IsEqualTo(3);
                    //connection.Execute("Delete from KeyMaster");
                }
            }


            public void TestFilteredWithSQLGetList()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestFilteredWithSQLGetList1", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredWithSQLGetList2", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredWithSQLGetList3", Age = 10 });
                    connection.Insert(new User { Name = "TestFilteredWithSQLGetList4", Age = 11 });

                    var user = connection.GetList<User>("where Name like 'TestFilteredWithSQLGetList%' and Age = 10");
                    //user.Count().IsEqualTo(3);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestGetListWithNullWhere()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestGetListWithNullWhere", Age = 10 });
                    var user = connection.GetList<User>(null);
                    // user.Count().IsEqualTo(1);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestGetListWithoutWhere()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestGetListWithoutWhere", Age = 10 });
                    var user = connection.GetList<User>();
                    //user.Count().IsEqualTo(1);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestsGetListWithParameters()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "TestsGetListWithParameters1", Age = 10 });
                    connection.Insert(new User { Name = "TestsGetListWithParameters2", Age = 10 });
                    connection.Insert(new User { Name = "TestsGetListWithParameters3", Age = 10 });
                    connection.Insert(new User { Name = "TestsGetListWithParameters4", Age = 11 });

                    var user = connection.GetList<User>("where Age > @Age", new { Age = 10 });
                    //user.Count().IsEqualTo(1);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestGetWithReadonlyProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestGetWithReadonlyProperty", Age = 10 });
                    var user = connection.Get<User>(id);
                    //user.CreatedDate.Year.IsEqualTo(DateTime.Now.Year);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestInsertWithReadonlyProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestInsertWithReadonlyProperty", Age = 10, CreatedDate = new DateTime(2001, 1, 1) });
                    var user = connection.Get<User>(id);
                    //the date can't be 2001 - it should be the autogenerated date from the database
                    //user.CreatedDate.Year.IsEqualTo(DateTime.Now.Year);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestUpdateWithReadonlyProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestUpdateWithReadonlyProperty", Age = 10 });
                    var user = connection.Get<User>(id);
                    user.Age = 11;
                    user.CreatedDate = new DateTime(2001, 1, 1);
                    connection.Update(user);
                    user = connection.Get<User>(id);
                    //don't allow changing created date since it has a readonly attribute
                    //user.CreatedDate.Year.IsEqualTo(DateTime.Now.Year);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestGetWithNotMappedProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestGetWithNotMappedProperty", Age = 10, NotMappedInt = 1000 });
                    var user = connection.Get<User>(id);
                    //user.NotMappedInt.IsEqualTo(0);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestInsertWithNotMappedProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestInsertWithNotMappedProperty", Age = 10, CreatedDate = new DateTime(2001, 1, 1), NotMappedInt = 1000 });
                    var user = connection.Get<User>(id);
                    // user.NotMappedInt.IsEqualTo(0);
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestUpdateWithNotMappedProperty()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new User { Name = "TestUpdateWithNotMappedProperty", Age = 10 });
                    var user = connection.Get<User>(id);
                    user.Age = 11;
                    user.CreatedDate = new DateTime(2001, 1, 1);
                    user.NotMappedInt = 1234;
                    connection.Update(user);
                    user = connection.Get<User>(id);

                    //user.NotMappedInt.IsEqualTo(0);
                    //
                    //connection.Execute("Delete from Users");
                }
            }

            public void TestInsertWithSpecifiedKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new Car { Make = "Honda", Model = "Civic" });
                    //id.IsEqualTo(1);
                }
            }

            public void TestInsertWithExtraPropertiesShouldSkipNonSimpleTypesAndPropertiesMarkedEditableFalse()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new Car { Make = "Honda", Model = "Civic", Users = new List<User> { new User { Age = 12, Name = "test" } } });
                    //id.IsEqualTo(2);
                }
            }

            public void TestUpdate()
            {
                using (var connection = GetOpenConnection())
                {
                    var newid = (int)connection.Insert(new Car { Make = "Honda", Model = "Civic" });
                    var newitem = connection.Get<Car>(newid);
                    newitem.Make = "Toyota";
                    connection.Update(newitem);
                    var updateditem = connection.Get<Car>(newid);
                    //updateditem.Make.IsEqualTo("Toyota");
                    connection.Delete<Car>(newid);
                }
            }

            /// <summary>
            /// We expect scheduled day off to NOT be updated, since it's not a property of UserEditableSettings
            /// </summary>
            public void TestUpdateUsingGenericLimitedFields()
            {
                using (var connection = GetOpenConnection())
                {
                    //arrange
                    var user = new User { Name = "User1", Age = 10, ScheduledDayOff = DayOfWeek.Friday };
                    user.Id = connection.Insert(user) ?? 0;

                    user.ScheduledDayOff = DayOfWeek.Thursday;
                    var userAsEditableSettings = (UserEditableSettings)user;
                    userAsEditableSettings.Name = "User++";

                    connection.Update(userAsEditableSettings);

                    //act
                    var insertedUser = connection.Get<User>(user.Id);

                    //assert
                    //insertedUser.Name.IsEqualTo("User++");
                    // insertedUser.ScheduledDayOff.IsEqualTo(DayOfWeek.Friday);

                    connection.Delete<User>(user.Id);
                }
            }

            public void TestDeleteByObjectWithAttributes()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new Car { Make = "Honda", Model = "Civic" });
                    var car = connection.Get<Car>(id);
                    connection.Delete(car);
                    //connection.Get<Car>(id).IsNull();
                }
            }

            public void TestDeleteByMultipleKeyObjectWithAttributes()
            {
                using (var connection = GetOpenConnection())
                {
                    var keyMaster = new KeyMaster { Key1 = 1, Key2 = 2 };
                    connection.Insert(keyMaster);
                    var car = connection.Get<KeyMaster>(new { Key1 = 1, Key2 = 2 });
                    connection.Delete(car);
                    //connection.Get<KeyMaster>(keyMaster).IsNull();
                }
            }

            public void TestComplexTypesMarkedEditableAreSaved()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = (int)connection.Insert(new User { Name = "User", Age = 11, ScheduledDayOff = DayOfWeek.Friday });
                    var user1 = connection.Get<User>(id);
                    //user1.ScheduledDayOff.IsEqualTo(DayOfWeek.Friday);
                    connection.Delete(user1);
                }
            }

            public void TestNullableSimpleTypesAreSaved()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = (int)connection.Insert(new User1 { Name = "User", Age = 11, ScheduledDayOff = 2 });
                    var user1 = connection.Get<User1>(id);
                    //user1.ScheduledDayOff.IsEqualTo(2);
                    connection.Delete(user1);
                }
            }

            public void TestInsertIntoDifferentSchema()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new CarLog { LogNotes = "blah blah blah" });
                    //id.IsEqualTo(1);
                    connection.Delete<CarLog>(id);

                }
            }

            public void TestGetFromDifferentSchema()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert(new CarLog { LogNotes = "TestGetFromDifferentSchema" });
                    var carlog = connection.Get<CarLog>(id);
                    //carlog.LogNotes.IsEqualTo("TestGetFromDifferentSchema");
                    connection.Delete<CarLog>(id);
                }
            }

            public void TestTryingToGetFromTableInSchemaWithoutDataAnnotationShouldFail()
            {
                using (var connection = GetOpenConnection())
                {
                    try
                    {
                        connection.Get<SchemalessCarLog>(1);
                    }
                    catch (Exception)
                    {
                        //we expect to get an exception, so return
                        return;
                    }

                    //if we get here without throwing an exception, the test failed.
                    throw new ApplicationException("Expected exception");
                }
            }

            public void TestGetFromTableWithNonIntPrimaryKey()
            {
                using (var connection = GetOpenConnection())
                {
                    //note - there's not support for inserts without a non-int id, so drop down to a normal execute
                    //connection.Execute("INSERT INTO CITY (NAME, POPULATION) VALUES ('Morgantown', 31000)");
                    var city = connection.Get<City>("Morgantown");
                    //city.Population.IsEqualTo(31000);
                }
            }

            public void TestDeleteFromTableWithNonIntPrimaryKey()
            {
                using (var connection = GetOpenConnection())
                {
                    //note - there's not support for inserts without a non-int id, so drop down to a normal execute
                    //connection.Execute("INSERT INTO CITY (NAME, POPULATION) VALUES ('Fairmont', 18737)");
                    //connection.Delete<City>("Fairmont").IsEqualTo(1);
                }
            }

            public void TestNullableEnumInsert()
            {
                using (var connection = GetOpenConnection())
                {
                    connection.Insert(new User { Name = "Enum-y", Age = 10, ScheduledDayOff = DayOfWeek.Thursday });
                    var user = connection.GetList<User>(new { Name = "Enum-y" }).FirstOrDefault() ?? new User();
                    //user.ScheduledDayOff.IsEqualTo(DayOfWeek.Thursday);
                    connection.Delete<User>(user.Id);
                }
            }

            //dialect test 

            public void TestChangeDialect()
            {
                DataBase.SetDialect(DataBase.Dialect.SQLServer);
                //DataBase.GetDialect().IsEqualTo(DataBase.Dialect.SQLServer.ToString());
                DataBase.SetDialect(DataBase.Dialect.PostgreSQL);
                //DataBase.GetDialect().IsEqualTo(DataBase.Dialect.PostgreSQL.ToString());
            }


            //        A GUID is being created and returned on insert but never actually
            //applied to the insert query.

            //This can be seen on a table where the key
            //is a GUID and defaults to (newid()) and no GUID is provided on the
            //insert. Dapper will generate a GUID but it is not applied so the GUID is
            //generated by newid() but the Dapper GUID is returned instead which is
            //incorrect.


            //GUID primary key tests

            public void TestInsertIntoTableWithUnspecifiedGuidKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var id = connection.Insert<Guid, GUIDTest>(new GUIDTest { Name = "GuidUser" });
                    //id.GetType().Name.IsEqualTo("Guid");
                    var record = connection.Get<GUIDTest>(id);
                    //record.Name.IsEqualTo("GuidUser");
                    connection.Delete<GUIDTest>(id);
                }
            }

            public void TestInsertIntoTableWithGuidKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var guid = new Guid("1a6fb33d-7141-47a0-b9fa-86a1a1945da9");
                    var id = connection.Insert<Guid, GUIDTest>(new GUIDTest { Name = "InsertIntoTableWithGuidKey", Id = guid });
                    //id.IsEqualTo(guid);
                    connection.Delete<GUIDTest>(id);
                }
            }

            public void TestGetRecordWithGuidKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var guid = new Guid("2a6fb33d-7141-47a0-b9fa-86a1a1945da9");
                    connection.Insert<Guid, GUIDTest>(new GUIDTest { Name = "GetRecordWithGuidKey", Id = guid });
                    var id = connection.GetList<GUIDTest>().First().Id;
                    var record = connection.Get<GUIDTest>(id);
                    //record.Name.IsEqualTo("GetRecordWithGuidKey");
                    connection.Delete<GUIDTest>(id);

                }
            }

            public void TestDeleteRecordWithGuidKey()
            {
                using (var connection = GetOpenConnection())
                {
                    var guid = new Guid("3a6fb33d-7141-47a0-b9fa-86a1a1945da9");
                    connection.Insert<Guid, GUIDTest>(new GUIDTest { Name = "DeleteRecordWithGuidKey", Id = guid });
                    var id = connection.GetList<GUIDTest>().First().Id;
                    connection.Delete<GUIDTest>(id);
                    //connection.Get<GUIDTest>(id).IsNull();
                }
            }

        }
    }
}
