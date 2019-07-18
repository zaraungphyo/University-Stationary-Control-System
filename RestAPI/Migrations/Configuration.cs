namespace RestAPI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RestAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<RestAPI.Models.ssisdbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestAPI.Models.ssisdbContext context)
        {

            base.Seed(context);

            #region Collection Point
            if (!context.CollectionPoints.Any())
            {
                context.CollectionPoints.AddOrUpdate(
                p => p.CollectionPointId,
                new CollectionPoint
                {
                    CollectionPointAddress = "Stationery Store - Administration Building",
                    CollectionTime = "9:30 AM"
                },
                new CollectionPoint
                {
                    CollectionPointAddress = "Management School",
                    CollectionTime = "11:00 AM"
                },
                new CollectionPoint
                {
                    CollectionPointAddress = "Medical School",
                    CollectionTime = "09:30 AM"
                },
                new CollectionPoint
                {
                    CollectionPointAddress = "Engineering School",
                    CollectionTime = "11:00 AM"
                },
                new CollectionPoint
                {
                    CollectionPointAddress = "Science School",
                    CollectionTime = "9:30 AM"
                },
                new CollectionPoint
                {
                    CollectionPointAddress = "University Hospital",
                    CollectionTime = "11:00 AM"
                });
                context.SaveChanges();
            }
            #endregion

            #region Department
            if (!context.Departments.Any())
            {
                context.Departments.AddOrUpdate(
              p => p.DepartmentId,
              new Department
              {
                  DepartmentName = "English Dept",
                  CollectionPointId = 1,
                  ContactName = "Mrs Pamela Kow",
                  PhoneNo = "8742234",
                  FaxNo = "8921456"
              },
              new Department
              {
                  DepartmentName = "Computer Science",
                  CollectionPointId = 5,
                  ContactName = "Mr Wee Kian Fatt",
                  PhoneNo = "8901235",
                  FaxNo = "8921457"
              },
              new Department
              {
                  DepartmentName = "Commerce Dept",
                  CollectionPointId = 2,
                  ContactName = "Mr Mohd. Azman",
                  PhoneNo = "8741256",
                  FaxNo = "8741284"
              },
              new Department
              {
                  DepartmentName = "Registrar Dept",
                  CollectionPointId = 3,
                  ContactName = "Ms Helen Ho",
                  PhoneNo = "8901266",
                  FaxNo = "8921465"
              },
                new Department
                {
                    DepartmentName = "Zoology Dept",
                    CollectionPointId = 3,
                    ContactName = "Mr. Peter Tan Ah Meng",
                    PhoneNo = "8901266",
                    FaxNo = "8921465"
                },
                 new Department
                 {
                     DepartmentName = "Arts & Humanities Dept",
                     CollectionPointId = 1,
                     ContactName = "Mrs Sridharan Jayanthi",
                     PhoneNo = "8955113",
                     FaxNo = "8935765"
                 },
                  new Department
                  {
                      DepartmentName = "Administration & Management Dept",
                      CollectionPointId = 2,
                      ContactName = "Mr Abdul Zaidi",
                      PhoneNo = "8718584",
                      FaxNo = "8753849"
                  },
                   new Department
                   {
                       DepartmentName = "Dentistry Dept",
                       CollectionPointId = 3,
                       ContactName = "Mr Khoo Chee Huat",
                       PhoneNo = "8934227",
                       FaxNo = "8922055"
                   },
                     new Department
                     {
                         DepartmentName = "Science Dept",
                         CollectionPointId = 5,
                         ContactName = "Mdm Low Soo Chiew",
                         PhoneNo = "8938529",
                         FaxNo = "9059304"
                     },

                  new Department
                  {
                      DepartmentName = "Engineering Dept",
                      CollectionPointId = 4,
                      ContactName = "Mr Seah Yang Hwee Raymond",
                      PhoneNo = "8759223",
                      FaxNo = "8754591"
                  });
                context.SaveChanges();
            }
            #endregion

            #region Category
            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(
                x => x.CategoryId,
            new Category()
            {
                CategoryName = "Clip"
            },
            new Category()
            {
                CategoryName = "Envelope"
            },
            new Category()
            {
                CategoryName = "Eraser"
            },
            new Category()
            {
                CategoryName = "Exercise"
            },
            new Category()
            {
                CategoryName = "File"
            },
            new Category()
            {
                CategoryName = "Pen"
            },
            new Category()
            {
                CategoryName = "Puncher"
            },
            new Category()
            {
                CategoryName = "Pad"
            },
            new Category()
            {
                CategoryName = "Paper"
            },
            new Category()
            {
                CategoryName = "Scissors"
            },
            new Category()
            {
                CategoryName = "Tape"
            },
            new Category()
            {
                CategoryName = "Sharpener"
            },
            new Category()
            {
                CategoryName = "Shorthand"
            },
            new Category()
            {
                CategoryName = "Stapler"
            }, new Category()
            {
                CategoryName = "Tacks"
            },
            new Category()
            {
                CategoryName = "TParency"
            },
            new Category()
            {
                CategoryName = "Tray"
            },
            new Category()
            {
                CategoryName = "Ruler"
            });
            }
            context.SaveChanges();
            #endregion

            #region MeasurementUnit
            if (!context.MeasurementUnits.Any())
            {
                context.MeasurementUnits.AddOrUpdate(
              p => p.UnitId,
              new MeasurementUnit
              {
                  UnitName = "Dozen",
                  UnitQuantity = 12
              },
              new MeasurementUnit
              {
                  UnitName = "Box",
                  UnitQuantity = 1
              },
               new MeasurementUnit
               {
                   UnitName = "Each",
                   UnitQuantity = 1
               },
                new MeasurementUnit
                {
                    UnitName = "Set",
                    UnitQuantity = 1
                },
              new MeasurementUnit
              {
                  UnitName = "Packet",
                  UnitQuantity = 10
              }
            );
                context.SaveChanges();
            }
            #endregion

            #region items
            if (!context.Items.Any())
            {
                context.Items.AddOrUpdate(
              p => p.ItemId,
              new Item
              {
                  ItemDescription = "Clips Double 1",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 1,
                  QuantityOnHand = 100,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Clips Double 2",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 1,
                  QuantityOnHand = 100,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Clips Double 3/4",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 1,
                  QuantityOnHand = 29,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Clips Paper Large",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 2,
                  QuantityOnHand = 100,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Clips Paper Medium",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 2,
                  QuantityOnHand = 100,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Clips Paper Small",
                  ReorderLevel = 50,
                  ReorderQuantity = 30,
                  UnitId = 2,
                  QuantityOnHand = 100,
                  CategoryId = 1,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope Brown (3\"x6\")",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope Brown (3\"x6\") w/Window",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope Brown (5\"x7\")",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope Brown (5\"x7\") w/Window",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope White (3\"x6\")",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope White (3\"x6\") w/Window",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope White (5\"x7\")",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 700,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Envelope White (5\"x7\") w/Window",
                  ReorderLevel = 600,
                  ReorderQuantity = 400,
                  UnitId = 3,
                  QuantityOnHand = 300,
                  CategoryId = 2,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Eraser (hard)",
                  ReorderLevel = 50,
                  ReorderQuantity = 20,
                  UnitId = 3,
                  QuantityOnHand = 100,
                  CategoryId = 3,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Eraser (soft)",
                  ReorderLevel = 50,
                  ReorderQuantity = 20,
                  UnitId = 3,
                  QuantityOnHand = 48,
                  CategoryId = 3,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Exercise Book (100 pg)",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 3,
                  QuantityOnHand = 200,
                  CategoryId = 4,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Exercise Book (120 pg)",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 3,
                  QuantityOnHand = 200,
                  CategoryId = 4,
                  Status = "1"
              },
            new Item
            {
                ItemDescription = "Exercise Book A4 Hardcover (100 pg)",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 4,
                Status = "1"
            },
              new Item
              {
                  ItemDescription = "Exercise Book A4 Hardcover (120 pg)",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 3,
                  QuantityOnHand = 200,
                  CategoryId = 4,
                  Status = "1"
              },
            new Item
            {
                ItemDescription = "Exercise Book A4 Hardcover (200 pg)",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 4,
                Status = "1"
            },
              new Item
              {
                  ItemDescription = "Exercise Book Hardcover (100 pg)",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 3,
                  QuantityOnHand = 99,
                  CategoryId = 4,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Exercise Book Hardcover (120 pg)",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 3,
                  QuantityOnHand = 200,
                  CategoryId = 4,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "File Separator",
                  ReorderLevel = 100,
                  ReorderQuantity = 50,
                  UnitId = 4,
                  QuantityOnHand = 200,
                  CategoryId = 5,
                  Status = "1"
              },
              new Item
              {
                  ItemDescription = "Trays In/Out",
                  ReorderLevel = 20,
                  ReorderQuantity = 10,
                  UnitId = 4,
                  QuantityOnHand = 60,
                  CategoryId = 17,
                  Status = "1"
              },
            new Item
            {
                ItemDescription = "File-Brown w/o Logo",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "File-Brown with Logo",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Folder Plastic Blue",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 188,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Folder Plastic Clear",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Folder Plastic Green",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Folder Plastic Pink",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Folder Plastic Yellow",
                ReorderLevel = 200,
                ReorderQuantity = 150,
                UnitId = 3,
                QuantityOnHand = 400,
                CategoryId = 5,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Highlighter Blue",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 1,
                QuantityOnHand = 180,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Highlighter Green",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 1,
                QuantityOnHand = 180,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Highlighter Pink",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 1,
                QuantityOnHand = 180,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Highlighter Yellow",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 1,
                QuantityOnHand = 180,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Hole Puncher 2 holes",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 70,
                CategoryId = 7,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Hole Puncher 3 holes",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 70,
                CategoryId = 7,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Hole Puncher Adjustable",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 70,
                CategoryId = 7,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 1\"x2\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 1\"x1\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 50,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 1\"x2\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 2\"x3\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 2\"x4\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 100,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 3\"x4\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pad Postit Memo 4\"x2\"",
                ReorderLevel = 100,
                ReorderQuantity = 60,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 8,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Paper Photostat A3",
                ReorderLevel = 500,
                ReorderQuantity = 500,
                UnitId = 2,
                QuantityOnHand = 1000,
                CategoryId = 9,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Paper Photostat A4",
                ReorderLevel = 500,
                ReorderQuantity = 500,
                UnitId = 2,
                QuantityOnHand = 1000,
                CategoryId = 9,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Ballpoint Black",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Ballpoint Blue",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 100,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Ballpoint Red",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Felt Tip Black",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Felt Tip Blue",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Felt Tip Red",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Transparency Permanent",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Sharpener",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 100,
                CategoryId = 12,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Shorthand Book (100 pg)",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 13,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Shorthand Book (120 pg)",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 13,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Shorthand Book (80 pg)",
                ReorderLevel = 100,
                ReorderQuantity = 80,
                UnitId = 3,
                QuantityOnHand = 99,
                CategoryId = 13,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Stapler No. 28",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 100,
                CategoryId = 14,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Stapler No. 36",
                ReorderLevel = 50,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 100,
                CategoryId = 14,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Thumb Tacks Large",
                ReorderLevel = 10,
                ReorderQuantity = 10,
                UnitId = 2,
                QuantityOnHand = 20,
                CategoryId = 15,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Thumb Tacks Medium",
                ReorderLevel = 10,
                ReorderQuantity = 10,
                UnitId = 2,
                QuantityOnHand = 20,
                CategoryId = 15,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Thumb Tacks Small",
                ReorderLevel = 10,
                ReorderQuantity = 10,
                UnitId = 2,
                QuantityOnHand = 20,
                CategoryId = 15,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Blue",
                ReorderLevel = 100,
                ReorderQuantity = 200,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 16,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Clear",
                ReorderLevel = 500,
                ReorderQuantity = 400,
                UnitId = 2,
                QuantityOnHand = 1000,
                CategoryId = 16,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Green",
                ReorderLevel = 100,
                ReorderQuantity = 200,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 16,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Red",
                ReorderLevel = 100,
                ReorderQuantity = 200,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 16,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Reverse Blue",
                ReorderLevel = 100,
                ReorderQuantity = 200,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 16,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Transparency Cover 3M",
                ReorderLevel = 500,
                ReorderQuantity = 400,
                UnitId = 2,
                QuantityOnHand = 1000,
                CategoryId = 16,
                Status = "1"
            }, new Item

            {

                ItemDescription = "Pen Transparency Soluble",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 5,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },

            new Item

            {
                ItemDescription = "Pen Whiteboard Marker Black",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Whiteboard Marker Blue",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Whiteboard Marker Green",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pen Whiteboard Marker Red",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 2,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pencil 2B with Eraser End",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pencil 4H",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pencil 2B",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pencil B",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Pencil B with Eraser",
                ReorderLevel = 100,
                ReorderQuantity = 50,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 6,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Ruler 12\"",
                ReorderLevel = 100,
                ReorderQuantity = 20,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 18,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Ruler 6\"",
                ReorderLevel = 100,
                ReorderQuantity = 20,
                UnitId = 1,
                QuantityOnHand = 200,
                CategoryId = 18,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Scissors",
                ReorderLevel = 100,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 10,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Scotch Tape",
                ReorderLevel = 100,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 11,
                Status = "1"
            },
            new Item
            {
                ItemDescription = "Scotch Tape Dispenser",
                ReorderLevel = 100,
                ReorderQuantity = 20,
                UnitId = 3,
                QuantityOnHand = 200,
                CategoryId = 11,
                Status = "1"
            });
                // context.SaveChanges();
            }
            #endregion


            #region Location
            if (!context.ItemLocations.Any())
            {
                context.ItemLocations.AddOrUpdate(
              l => l.LocationId,
              new ItemLocation()
              {
                  LocationDesc = "Level 1, Case 1, Row Number 1"
              },
              new ItemLocation()
              {
                  LocationDesc = "Level 1, Case 1, Row Number 2"
              },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 1, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 2, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 2, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 2, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 3, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 3, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 3, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 4, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 4, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 4, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 5, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 5, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 5, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 6, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 6, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 1, Case 6, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 1, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 1, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 1, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 2, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 2, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 2, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 3, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 3, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 3, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 4, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 4, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 4, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 5, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 5, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 5, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 6, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 6, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 2, Case 6, Row Number 3"
               },

               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 1, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 1, Row Number 2"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 1, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 2, Row Number 1"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 2, Row Number 2"
               },
                new ItemLocation()
                {
                    LocationDesc = "Level 3, Case 2, Row Number 3"
                },
                 new ItemLocation()
                 {
                     LocationDesc = "Level 3, Case 3, Row Number 1"
                 },
                  new ItemLocation()
                  {
                      LocationDesc = "Level 3, Case 3, Row Number 2"
                  },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 3, Row Number 3"
               },
               new ItemLocation()
               {
                   LocationDesc = "Level 3, Case 4, Row Number 1"
               },
                new ItemLocation()
                {
                    LocationDesc = "Level 3, Case 4, Row Number 2"
                },
                 new ItemLocation()
                 {
                     LocationDesc = "Level 3, Case 4, Row Number 3"
                 },
                new ItemLocation()
                {
                    LocationDesc = "Level 3, Case 5, Row Number 1"
                },
                new ItemLocation()
                {
                    LocationDesc = "Level 3, Case 5, Row Number 2"
                },
                 new ItemLocation()
                 {
                     LocationDesc = "Level 3, Case 5, Row Number 3"
                 },
                 new ItemLocation()
                 {
                     LocationDesc = "Level 3, Case 6, Row Number 1"
                 },
                new ItemLocation()
                {
                    LocationDesc = "Level 3, Case 6, Row Number 2"
                },
                 new ItemLocation()
                 {
                     LocationDesc = "Level 3, Case 6, Row Number 3"
                 });
                // context.SaveChanges();
            }
            #endregion


            #region Supplier
            if (!context.Suppliers.Any())
            {
                context.Suppliers.AddOrUpdate(
                  p => p.SupplierId,
                  new Supplier
                  {
                      SupplierName = "ALPHA Office Supplies",
                      ContactName = "Ms Irene Tan",
                      PhoneNo = "4619928",
                      FaxNo = "4612238",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8500440-2",
                      Status = "1",
                      Address = @"Blk 1128, Ang Mo Kio Industrial Park \n #02-1108 Ang Mo Kio Street 62 \n Singapore 622262"
                  }, new Supplier
                  {
                      SupplierName = "Cheap Stationery",
                      ContactName = "Mr Soh Kway Koh",
                      PhoneNo = "3543234",
                      FaxNo = "4742434",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "Nil",
                      Status = "1",
                      Address = @"Blk 34, Clementi Road \n #07-02 Ban Ban Soh Building \n Singapore 110525"
                  }, new Supplier
                  {
                      SupplierName = "BANES Shop",
                      ContactName = "Mr Loh Ah Pek",
                      PhoneNo = "4781234",
                      FaxNo = "4792434",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8200420-2",
                      Status = "1",
                      Address = @"Blk 124, Alexandra Road \n #03-04 Banes Building \n Singapore 550315"
                  }, new Supplier
                  {
                      SupplierName = "OMEGA Stationery Supplier",
                      ContactName = "Mr Ronnie Ho",
                      PhoneNo = "7671233",
                      FaxNo = "7671234",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8555330-1",
                      Status = "0",
                      Address = @"Blk 11, Hillview Avenue \n #03-04, \n Singapore 679036"
                  }, new Supplier
                  {
                      SupplierName = "POPULAR Stationery Shop",
                      ContactName = "Ms Stella Ng",
                      PhoneNo = "2420425",
                      FaxNo = "8738529",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "Nil",
                      Status = "0",
                      Address = @"Blk 503, Elias Road \n #01-28, \n Singapore 550503"
                  }, new Supplier
                  {
                      SupplierName = "Evergreen Stationery Pte Ltd",
                      ContactName = "Mr Soh Lai Fa",
                      PhoneNo = "6969696",
                      FaxNo = "7759223",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8556630-1",
                      Status = "0",
                      Address = @"Blk 315, Ubi Avenue 1 \n #01-393, \n Singapore 123315"
                  }, new Supplier
                  {
                      SupplierName = "Bras Basah Stationery Shop Pte Ltd",
                      ContactName = "Mdm Mary Tan",
                      PhoneNo = "7755113",
                      FaxNo = "7620324",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8765000-1",
                      Status = "0",
                      Address = @"Blk 109, Bedok North Road \n 06-2316, \n Singapore 104109"
                  }, new Supplier
                  {
                      SupplierName = "Seng Yew Stationery Shop Pte Ltd",
                      ContactName = "Mr Terence Lim",
                      PhoneNo = "2352345",
                      FaxNo = "6658037",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8674332-2",
                      Status = "0",
                      Address = @"Blk 244, Bukit Panjang Ring Road \n #01-184, \n Singapore 680244"
                  }, new Supplier
                  {
                      SupplierName = "Peng You Bookshop & Stationery",
                      ContactName = "Ms Vanessa Ong",
                      PhoneNo = "7690237",
                      FaxNo = "3551385",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "Nil",
                      Status = "0",
                      Address = @"Blk 232, Jurong East Street 12 \n #02-436, \n Singapore 140232"
                  }, new Supplier
                  {
                      SupplierName = "Modern Stationery Supermart",
                      ContactName = "Mdm Margaret Ng",
                      PhoneNo = "3533819",
                      FaxNo = "2827208",
                      Email = "e0321101@gmail.com",
                      GstRegistrationNo = "MR-8829209-2",
                      Status = "0",
                      Address = @"Blk 99, Balestier Road \n #01-168, \n Singapore 123299"
                  });
                // context.SaveChanges();
            }
            #endregion

            #region SupplierItems
            if (!context.SupplierItems.Any())
            {
                context.SupplierItems.AddOrUpdate(
                p => p.SupplierItemId,
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 1,
                    UnitId = 1,
                    TenderPrice = 2.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 1,
                    UnitId = 1,
                    TenderPrice = 2.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 2,
                    UnitId = 1,
                    TenderPrice = 2.6M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 2,
                    UnitId = 1,
                    TenderPrice = 2.7M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 2,
                    UnitId = 1,
                    TenderPrice = 2.8M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 3,
                    UnitId = 1,
                    TenderPrice = 3.8M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 3,
                    UnitId = 1,
                    TenderPrice = 3.9M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 3,
                    UnitId = 1,
                    TenderPrice = 4.0M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 4,
                    UnitId = 2,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 4,
                    UnitId = 2,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 4,
                    UnitId = 2,
                    TenderPrice = 5.7M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 5,
                    UnitId = 2,
                    TenderPrice = 5.9M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 5,
                    UnitId = 2,
                    TenderPrice = 6.0M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 5,
                    UnitId = 2,
                    TenderPrice = 6.1M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 6,
                    UnitId = 2,
                    TenderPrice = 4.7M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 6,
                    UnitId = 2,
                    TenderPrice = 4.8M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 6,
                    UnitId = 2,
                    TenderPrice = 4.9M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 7,
                    UnitId = 3,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 7,
                    UnitId = 3,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 7,
                    UnitId = 3,
                    TenderPrice = 3.7M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 8,
                    UnitId = 3,
                    TenderPrice = 4.1M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 8,
                    UnitId = 3,
                    TenderPrice = 4.2M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 9,
                    UnitId = 3,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 9,
                    UnitId = 3,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 10,
                    UnitId = 3,
                    TenderPrice = 6.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 10,
                    UnitId = 3,
                    TenderPrice = 6.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 11,
                    UnitId = 3,
                    TenderPrice = 5.6M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 11,
                    UnitId = 3,
                    TenderPrice = 5.7M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 11,
                    UnitId = 3,
                    TenderPrice = 5.8M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 12,
                    UnitId = 3,
                    TenderPrice = 4.6M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 12,
                    UnitId = 3,
                    TenderPrice = 4.7M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 12,
                    UnitId = 3,
                    TenderPrice = 4.8M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 13,
                    UnitId = 3,
                    TenderPrice = 6.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 13,
                    UnitId = 3,
                    TenderPrice = 6.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 14,
                    UnitId = 3,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 14,
                    UnitId = 3,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 14,
                    UnitId = 3,
                    TenderPrice = 5.7M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 15,
                    UnitId = 3,
                    TenderPrice = 4.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 15,
                    UnitId = 3,
                    TenderPrice = 4.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 15,
                    UnitId = 3,
                    TenderPrice = 4.4M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 16,
                    UnitId = 3,
                    TenderPrice = 0.48M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 16,
                    UnitId = 3,
                    TenderPrice = 0.49M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 16,
                    UnitId = 3,
                    TenderPrice = 0.5M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 17,
                    UnitId = 3,
                    TenderPrice = 0.22M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 17,
                    UnitId = 3,
                    TenderPrice = 0.23M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 17,
                    UnitId = 3,
                    TenderPrice = 0.24M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 18,
                    UnitId = 3,
                    TenderPrice = 0.23M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 18,
                    UnitId = 3,
                    TenderPrice = 0.24M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 18,
                    UnitId = 3,
                    TenderPrice = 0.25M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 19,
                    UnitId = 3,
                    TenderPrice = 3.4M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 19,
                    UnitId = 3,
                    TenderPrice = 3.5M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 19,
                    UnitId = 3,
                    TenderPrice = 3.6M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 20,
                    UnitId = 3,
                    TenderPrice = 0.54M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 20,
                    UnitId = 3,
                    TenderPrice = 0.55M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 20,
                    UnitId = 3,
                    TenderPrice = 0.56M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 21,
                    UnitId = 3,
                    TenderPrice = 4.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 21,
                    UnitId = 3,
                    TenderPrice = 0.61M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 21,
                    UnitId = 3,
                    TenderPrice = 0.62M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 22,
                    UnitId = 3,
                    TenderPrice = 0.63M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 22,
                    UnitId = 3,
                    TenderPrice = 4.7M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 22,
                    UnitId = 3,
                    TenderPrice = 4.8M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 23,
                    UnitId = 3,
                    TenderPrice = 1.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 23,
                    UnitId = 3,
                    TenderPrice = 1.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 23,
                    UnitId = 3,
                    TenderPrice = 1.2M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 24,
                    UnitId = 4,
                    TenderPrice = 1.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 24,
                    UnitId = 4,
                    TenderPrice = 1.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 24,
                    UnitId = 4,
                    TenderPrice = 1.4M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 25,
                    UnitId = 4,
                    TenderPrice = 2.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 25,
                    UnitId = 4,
                    TenderPrice = 2.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 25,
                    UnitId = 4,
                    TenderPrice = 2.4M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 26,
                    UnitId = 3,
                    TenderPrice = 3.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 26,
                    UnitId = 3,
                    TenderPrice = 3.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 26,
                    UnitId = 3,
                    TenderPrice = 3.5M,
                    Priority = 3
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 27,
                    UnitId = 3,
                    TenderPrice = 3.4M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 27,
                    UnitId = 3,
                    TenderPrice = 3.5M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 28,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 28,
                    UnitId = 3,
                    TenderPrice = 2.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 29,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 29,
                    UnitId = 3,
                    TenderPrice = 2.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 30,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 30,
                    UnitId = 3,
                    TenderPrice = 2.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 31,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 31,
                    UnitId = 3,
                    TenderPrice = 2.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 32,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 32,
                    UnitId = 3,
                    TenderPrice = 2.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 33,
                    UnitId = 1,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 33,
                    UnitId = 1,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 34,
                    UnitId = 1,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 34,
                    UnitId = 1,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 35,
                    UnitId = 1,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 35,
                    UnitId = 1,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 36,
                    UnitId = 1,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 36,
                    UnitId = 1,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 37,
                    UnitId = 3,
                    TenderPrice = 2.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 37,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 38,
                    UnitId = 3,
                    TenderPrice = 2.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 38,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 39,
                    UnitId = 3,
                    TenderPrice = 2.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 39,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 40,
                    UnitId = 5,
                    TenderPrice = 3.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 40,
                    UnitId = 5,
                    TenderPrice = 3.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 41,
                    UnitId = 5,
                    TenderPrice = 5.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 41,
                    UnitId = 5,
                    TenderPrice = 5.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 42,
                    UnitId = 5,
                    TenderPrice = 5.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 42,
                    UnitId = 5,
                    TenderPrice = 5.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 43,
                    UnitId = 5,
                    TenderPrice = 5.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 43,
                    UnitId = 5,
                    TenderPrice = 5.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 44,
                    UnitId = 5,
                    TenderPrice = 5.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 44,
                    UnitId = 5,
                    TenderPrice = 5.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 45,
                    UnitId = 5,
                    TenderPrice = 5.3M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 45,
                    UnitId = 5,
                    TenderPrice = 5.4M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 46,
                    UnitId = 5,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 46,
                    UnitId = 5,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 47,
                    UnitId = 2,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 47,
                    UnitId = 2,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 48,
                    UnitId = 2,
                    TenderPrice = 2.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 48,
                    UnitId = 2,
                    TenderPrice = 2.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 49,
                    UnitId = 1,
                    TenderPrice = 4.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 49,
                    UnitId = 1,
                    TenderPrice = 4.6M,
                    Priority = 2
                },


                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 50,
                    UnitId = 1,
                    TenderPrice = 4.5M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 50,
                    UnitId = 1,
                    TenderPrice = 4.6M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 51,
                    UnitId = 1,
                    TenderPrice = 4.5M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 51,
                    UnitId = 1,
                    TenderPrice = 4.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 52,
                    UnitId = 1,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 52,
                    UnitId = 1,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 53,
                    UnitId = 1,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 53,
                    UnitId = 1,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 54,
                    UnitId = 1,
                    TenderPrice = 5.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 54,
                    UnitId = 1,
                    TenderPrice = 5.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 55,
                    UnitId = 5,
                    TenderPrice = 3.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 55,
                    UnitId = 5,
                    TenderPrice = 3.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 56,
                    UnitId = 3,
                    TenderPrice = 2.7M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 56,
                    UnitId = 3,
                    TenderPrice = 2.8M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 57,
                    UnitId = 3,
                    TenderPrice = 0.5M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 57,
                    UnitId = 3,
                    TenderPrice = 0.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 58,
                    UnitId = 3,
                    TenderPrice = 0.45M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 58,
                    UnitId = 3,
                    TenderPrice = 0.55M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 59,
                    UnitId = 3,
                    TenderPrice = 2.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 59,
                    UnitId = 3,
                    TenderPrice = 2.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 60,
                    UnitId = 3,
                    TenderPrice = 2.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 60,
                    UnitId = 3,
                    TenderPrice = 2.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 61,
                    UnitId = 3,
                    TenderPrice = 2.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 61,
                    UnitId = 3,
                    TenderPrice = 2.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 62,
                    UnitId = 2,
                    TenderPrice = 1.2M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 62,
                    UnitId = 2,
                    TenderPrice = 1.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 63,
                    UnitId = 2,
                    TenderPrice = 1.5M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 62,
                    UnitId = 2,
                    TenderPrice = 1.6M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 63,
                    UnitId = 2,
                    TenderPrice = 2.1M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 63,
                    UnitId = 2,
                    TenderPrice = 2.2M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 64,
                    UnitId = 2,
                    TenderPrice = 2.4M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 64,
                    UnitId = 2,
                    TenderPrice = 2.5M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 65,
                    UnitId = 2,
                    TenderPrice = 2.6M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 65,
                    UnitId = 2,
                    TenderPrice = 2.7M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 66,
                    UnitId = 2,
                    TenderPrice = 2.8M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 66,
                    UnitId = 2,
                    TenderPrice = 2.9M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 67,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 68,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 68,
                    UnitId = 2,
                    TenderPrice = 4.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 69,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 69,
                    UnitId = 2,
                    TenderPrice = 4.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 70,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 70,
                    UnitId = 2,
                    TenderPrice = 4.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 71,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 71,
                    UnitId = 2,
                    TenderPrice = 4.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 72,
                    UnitId = 2,
                    TenderPrice = 4.0M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 72,
                    UnitId = 2,
                    TenderPrice = 4.1M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 73,
                    UnitId = 5,
                    TenderPrice = 2.9M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 73,
                    UnitId = 5,
                    TenderPrice = 3.0M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 74,
                    UnitId = 2,
                    TenderPrice = 1.8M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 74,
                    UnitId = 2,
                    TenderPrice = 1.9M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 75,
                    UnitId = 2,
                    TenderPrice = 1.8M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 75,
                    UnitId = 2,
                    TenderPrice = 1.9M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 76,
                    UnitId = 2,
                    TenderPrice = 1.8M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 76,
                    UnitId = 2,
                    TenderPrice = 1.9M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 77,
                    UnitId = 2,
                    TenderPrice = 1.8M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 77,
                    UnitId = 2,
                    TenderPrice = 1.9M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 78,
                    UnitId = 1,
                    TenderPrice = 0.98M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 78,
                    UnitId = 1,
                    TenderPrice = 0.99M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 79,
                    UnitId = 1,
                    TenderPrice = 1.0M,
                    Priority = 1
                },

                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 79,
                    UnitId = 1,
                    TenderPrice = 1.1M,
                    Priority = 2
                },

                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 80,
                    UnitId = 1,
                    TenderPrice = 1.0M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 80,
                    UnitId = 1,
                    TenderPrice = 1.1M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 81,
                    UnitId = 1,
                    TenderPrice = 1.2M,
                    Priority = 1
                },


                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 81,
                    UnitId = 1,
                    TenderPrice = 1.3M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 82,
                    UnitId = 1,
                    TenderPrice = 1.1M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 2,
                    ItemId = 82,
                    UnitId = 1,
                    TenderPrice = 1.2M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 83,
                    UnitId = 1,
                    TenderPrice = 1.1M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 83,
                    UnitId = 1,
                    TenderPrice = 1.2M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 84,
                    UnitId = 1,
                    TenderPrice = 2.1M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 84,
                    UnitId = 1,
                    TenderPrice = 2.2M,
                    Priority = 2
                },
                new SupplierItem
                {
                    SupplierId = 3,
                    ItemId = 85,
                    UnitId = 1,
                    TenderPrice = 1.8M,
                    Priority = 1
                },
                new SupplierItem
                {
                    SupplierId = 1,
                    ItemId = 85,
                    UnitId = 1,
                    TenderPrice = 1.8m,
                    Priority = 2
                }
            );
                context.SaveChanges();
            }
            #endregion

            #region Disbursements
            if (!context.Disbursements.Any())
            {
                context.Disbursements.AddOrUpdate(
                p => p.DisbursementId,
                 new Disbursement
                 {
                     ItemId = 48,
                     DepartmentId = 1,
                     ActualQuantity = 10,
                     NeededQuantity = 5,
                     RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                     ACKStatus = "0"
                 },

                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2018-04-13").Date,
                    ACKStatus = "0"
                },

                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 20,
                    NeededQuantity = 20,
                    RetrievalDate = Convert.ToDateTime("2018-04-14").Date,
                    ACKStatus = "0"
                },

                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                    ACKStatus = "0"
                },

                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 10,
                    NeededQuantity = 10,
                    RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 12,
                    NeededQuantity = 12,
                    RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 17,
                    NeededQuantity = 17,
                    RetrievalDate = Convert.ToDateTime("2018-04-17").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 13,
                    NeededQuantity = 13,
                    RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 9,
                    NeededQuantity = 9,
                    RetrievalDate = Convert.ToDateTime("2018-04-14").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 50,
                    NeededQuantity = 50,
                    RetrievalDate = Convert.ToDateTime("2018-04-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 20,
                    NeededQuantity = 20,
                    RetrievalDate = Convert.ToDateTime("2018-05-10").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 25,
                    NeededQuantity = 25,
                    RetrievalDate = Convert.ToDateTime("2018-05-05").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 20,
                    NeededQuantity = 20,
                    RetrievalDate = Convert.ToDateTime("2018-05-10").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 47,
                    NeededQuantity = 47,
                    RetrievalDate = Convert.ToDateTime("2018-05-10").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 47,
                    NeededQuantity = 47,
                    RetrievalDate = Convert.ToDateTime("2018-05-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 92,
                    NeededQuantity = 92,
                    RetrievalDate = Convert.ToDateTime("2018-05-28").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 9,
                    NeededQuantity = 9,
                    RetrievalDate = Convert.ToDateTime("2018-05-28").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 29,
                    NeededQuantity = 29,
                    RetrievalDate = Convert.ToDateTime("2018-05-28").Date,
                    ACKStatus = "0"
                },

                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 10,
                    NeededQuantity = 10,
                    RetrievalDate = Convert.ToDateTime("2018-05-28").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 30,
                    NeededQuantity = 30,
                    RetrievalDate = Convert.ToDateTime("2018-06-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 50,
                    NeededQuantity = 50,
                    RetrievalDate = Convert.ToDateTime("2018-06-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 100,
                    NeededQuantity = 100,
                    RetrievalDate = Convert.ToDateTime("2018-06-18").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 35,
                    NeededQuantity = 35,
                    RetrievalDate = Convert.ToDateTime("2018-06-07").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 120,
                    NeededQuantity = 120,
                    RetrievalDate = Convert.ToDateTime("2018-06-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 10,
                    NeededQuantity = 10,
                    RetrievalDate = Convert.ToDateTime("2018-06-28").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 90,
                    NeededQuantity = 90,
                    RetrievalDate = Convert.ToDateTime("2018-06-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 30,
                    NeededQuantity = 30,
                    RetrievalDate = Convert.ToDateTime("2018-06-16").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 100,
                    NeededQuantity = 100,
                    RetrievalDate = Convert.ToDateTime("2018-07-02").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 111,
                    NeededQuantity = 111,
                    RetrievalDate = Convert.ToDateTime("2018-07-07").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 9,
                    NeededQuantity = 9,
                    RetrievalDate = Convert.ToDateTime("2018-07-02").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 18,
                    NeededQuantity = 18,
                    RetrievalDate = Convert.ToDateTime("2018-07-22").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 73,
                    NeededQuantity = 73,
                    RetrievalDate = Convert.ToDateTime("2018-07-10").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 28,
                    NeededQuantity = 28,
                    RetrievalDate = Convert.ToDateTime("2018-07-02").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2018-07-09").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 20,
                    NeededQuantity = 20,
                    RetrievalDate = Convert.ToDateTime("2018-07-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 80,
                    NeededQuantity = 80,
                    RetrievalDate = Convert.ToDateTime("2018-07-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 10,
                    NeededQuantity = 10,
                    RetrievalDate = Convert.ToDateTime("2018-07-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 11,
                    NeededQuantity = 11,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 31,
                    NeededQuantity = 31,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 55,
                    NeededQuantity = 55,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 200,
                    NeededQuantity = 200,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 3,
                    NeededQuantity = 3,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 30,
                    NeededQuantity = 30,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 50,
                    NeededQuantity = 50,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 5,
                    NeededQuantity = 5,
                    RetrievalDate = Convert.ToDateTime("2018-08-12").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 120,
                    NeededQuantity = 120,
                    RetrievalDate = Convert.ToDateTime("2018-08-13").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 13,
                    NeededQuantity = 13,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 100,
                    NeededQuantity = 100,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 50,
                    NeededQuantity = 50,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 35,
                    NeededQuantity = 35,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 43,
                    NeededQuantity = 43,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 221,
                    NeededQuantity = 221,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 25,
                    NeededQuantity = 25,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 30,
                    NeededQuantity = 30,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 83,
                    NeededQuantity = 83,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 6,
                    NeededQuantity = 6,
                    RetrievalDate = Convert.ToDateTime("2018-09-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 102,
                    NeededQuantity = 102,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 6,
                    NeededQuantity = 6,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 96,
                    NeededQuantity = 96,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 26,
                    NeededQuantity = 26,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 71,
                    NeededQuantity = 71,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 26,
                    NeededQuantity = 26,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 133,
                    NeededQuantity = 133,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 16,
                    NeededQuantity = 16,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 26,
                    NeededQuantity = 26,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 60,
                    NeededQuantity = 60,
                    RetrievalDate = Convert.ToDateTime("2018-10-20").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 23,
                    NeededQuantity = 23,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 1,
                    NeededQuantity = 1,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 13,
                    NeededQuantity = 13,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 95,
                    NeededQuantity = 95,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 11,
                    NeededQuantity = 11,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 43,
                    NeededQuantity = 43,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 23,
                    NeededQuantity = 23,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 70,
                    NeededQuantity = 70,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 43,
                    NeededQuantity = 43,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 203,
                    NeededQuantity = 203,
                    RetrievalDate = Convert.ToDateTime("2018-10-15").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 6,
                    NeededQuantity = 6,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 77,
                    NeededQuantity = 77,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 12,
                    NeededQuantity = 12,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 96,
                    NeededQuantity = 96,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 53,
                    NeededQuantity = 53,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 16,
                    NeededQuantity = 16,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 261,
                    NeededQuantity = 261,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 33,
                    NeededQuantity = 33,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 56,
                    NeededQuantity = 56,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 4,
                    NeededQuantity = 4,
                    RetrievalDate = Convert.ToDateTime("2018-11-21").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 24,
                    NeededQuantity = 24,
                    RetrievalDate = Convert.ToDateTime("2018-12-01").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 49,
                    NeededQuantity = 49,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 60,
                    NeededQuantity = 60,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 13,
                    NeededQuantity = 13,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 55,
                    NeededQuantity = 55,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 31,
                    NeededQuantity = 31,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 4,
                    NeededQuantity = 4,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 18,
                    NeededQuantity = 18,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 9,
                    NeededQuantity = 9,
                    RetrievalDate = Convert.ToDateTime("2018-12-08").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 1,
                    ActualQuantity = 9,
                    NeededQuantity = 9,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 2,
                    ActualQuantity = 5,
                    NeededQuantity = 5,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 3,
                    ActualQuantity = 18,
                    NeededQuantity = 18,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 4,
                    ActualQuantity = 25,
                    NeededQuantity = 25,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 5,
                    ActualQuantity = 2,
                    NeededQuantity = 2,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 6,
                    ActualQuantity = 15,
                    NeededQuantity = 15,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 7,
                    ActualQuantity = 29,
                    NeededQuantity = 29,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 8,
                    ActualQuantity = 3,
                    NeededQuantity = 3,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 9,
                    ActualQuantity = 21,
                    NeededQuantity = 21,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                },
                new Disbursement
                {
                    ItemId = 48,
                    DepartmentId = 10,
                    ActualQuantity = 59,
                    NeededQuantity = 59,
                    RetrievalDate = Convert.ToDateTime("2019-01-19").Date,
                    ACKStatus = "0"
                });
                context.SaveChanges();
            }
            #endregion


            Task.Run(async () => { await SeedAsyncUserRoles(context); }).Wait();
        }

        private async Task SeedAsyncUserRoles(ssisdbContext context)
        {

            UserManager<EmployeeModel> userManager = new UserManager<EmployeeModel>(new UserStore<EmployeeModel>(context));
            string[] roles = new string[] { "Administrator", "DepartmentHead", "TemporaryDepartmentHead", "DepartmentRep", "StoreClerk", "Employee", "StoreSupervisor", "StoreManager" };
            foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    context.Roles.Add(new IdentityRole(role));
                }
            }

            //create user UserName:Owner Role:Admin
            if (!context.Users.Any(u => u.UserName == "Administrator"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "System Administrator",
                    Email = "ssis.administrator@gmail.com",
                    UserName = "Administrator",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Administrator");
            }

            if (!context.Users.Any(u => u.UserName == "ezrapound"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Prof Ezra Pound",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "ezrapound",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "employee12"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee12",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee12",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee13"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee13",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee13",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee14"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee14",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee14",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee15"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee15",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee15",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee16"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee16",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee16",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee17"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee17",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee17",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee18"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee18",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee18",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "pamelakow"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Pamela Kow",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "pamelakow",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee110"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee110",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee110",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 1

                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }

            if (!context.Users.Any(u => u.UserName == "employee111"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee111",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee111",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1121"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1121",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1121",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee113"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee113",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee113",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee114"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee114",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee114",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee115"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee115",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee115",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee116"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee116",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee116",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee117"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee117",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee117",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee118"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee118",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee118",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee119"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee119",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee119",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee120"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee120",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee120",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee121"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee121",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee121",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee122"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee122",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee122",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1231"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1231",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1231",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee124"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee124",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee124",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee125"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee125",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee125",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee126"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee126",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee126",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee127"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee127",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee127",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee128"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee128",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee128",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee129"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee129",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee129",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee130"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee130",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee130",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee131"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee131",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee131",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee132"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee132",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee132",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee133"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee133",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee133",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee134"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee134",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee134",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee135"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee135",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee135",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee136"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee136",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee136",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee137"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee137",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee137",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee138"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee138",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee138",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee139"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee139",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee139",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee140"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee140",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee140",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee141"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee141",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee141",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee142"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee142",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee142",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee143"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee143",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee143",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee144"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee144",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee144",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee145"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee145",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee145",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee146"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee146",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee146",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee147"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee147",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee147",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee148"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee148",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee148",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee149"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee149",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee149",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee150"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee150",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee150",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 1,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }


            if (!context.Users.Any(u => u.UserName == "sohkianwee"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Dr. Soh Kian Wee",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "sohkianwee",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }
            if (!context.Users.Any(u => u.UserName == "employee21"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee21",
                    Email = "employee1@gmail.com",
                    UserName = "employee21",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee22"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee22",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee22",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee23"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee23",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee23",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee24"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee24",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee24",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee25"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee25",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee25",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee26"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee26",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee26",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee27"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee27",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee27",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee28"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee28",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee28",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee29"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee29",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee29",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee210"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee210",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee210",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee211"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee211",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee211",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee212"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee212",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee212",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee213"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee213",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee213",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee214"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee214",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee214",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee215"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee215",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee215",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee216"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee216",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee216",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee217"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee217",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee217",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee218"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee218",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee218",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee219"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee219",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee219",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee220"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee220",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee220",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee221"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee221",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee221",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee222"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee222",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee222",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee223"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee223",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee223",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee224"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee224",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee224",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee225"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee225",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee225",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee226"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee226",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee226",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee227"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee227",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee227",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "weekianfatt"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Wee Kian Fatt",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "weekianfatt",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee229"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee229",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee229",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee230"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee230",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee230",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee231"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee231",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee231",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee232"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee232",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee232",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee233"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee233",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee233",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee234"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee234",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee234",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee235"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee235",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee235",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee236"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee236",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee236",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee237"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee237",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee237",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee238"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee238",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee238",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee239"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee239",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee239",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee240"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee240",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee240",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee241"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee241",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee241",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee242"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee242",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee242",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee243"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee243",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee243",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee244"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee244",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee244",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee245"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee245",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee245",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee246"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee246",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee246",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee247"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee247",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee247",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee248"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee248",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee248",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee249"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee249",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee249",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 2,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }


            if (!context.Users.Any(u => u.UserName == "chialeowbee"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Dr. Chia Leow Bee",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "chialeowbee",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }


            if (!context.Users.Any(u => u.UserName == "employee32"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee32",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee32",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee33"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee33",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee33",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee34"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee34",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee34",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee35"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee35",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee35",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee36"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee36",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee36",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee37"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee37",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee37",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee38"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee38",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee38",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee39"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee39",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee39",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee310"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee310",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee310",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee311"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee311",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee311",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee312"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee312",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee312",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee313"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee313",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee313",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee314"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee314",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee314",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee315"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee315",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee315",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee316"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee316",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee316",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee317"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee317",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee317",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee318"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee318",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee318",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }

            if (!context.Users.Any(u => u.UserName == "employee319"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee19",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee319",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee320"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee320",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee320",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee321"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee321",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee321",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee322"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee322",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee322",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee323"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee323",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee323",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee324"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee324",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee324",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee325"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee325",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee325",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee326"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee326",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee326",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee327"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee327",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee327",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee328"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee328",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee328",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee329"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee329",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee329",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee330"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee330",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee330",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee331"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee331",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee331",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee332"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee332",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee332",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee333"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee333",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee333",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee334"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee334",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee334",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "mohdazman"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Mohd. Azman",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "mohdazman",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee336"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee336",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee336",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee337"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee337",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee337",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee338"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee338",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee338",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee339"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee339",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee339",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee340"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee340",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee340",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee341"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee341",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee341",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee342"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee342",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee342",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee343"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee343",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee343",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee344"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee344",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee344",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee345"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee345",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee345",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee346"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee346",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee346",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee347"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee347",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee347",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee48"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee348",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee348",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee349"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee349",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee349",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee350"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee350",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee350",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 3,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }





            if (!context.Users.Any(u => u.UserName == "lowkwayboo"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Low Kway Boo",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "lowkwayboo",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
                //  context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == "employee42"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee42",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee42",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee43"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee43",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee43",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee44"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee44",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee44",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee45"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee45",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee45",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee46"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee46",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee46",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee47"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee47",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee47",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee48"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee48",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee48",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee49"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee49",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee49",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee410"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee410",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee410",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }

            if (!context.Users.Any(u => u.UserName == "employee411"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee411",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee411",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee412"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee412",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee412",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee413"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee413",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee413",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee414"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee414",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee414",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee415"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee415",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee415",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee416"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee416",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee416",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee417"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee417",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee417",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee418"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee418",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee418",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee419"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee419",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee419",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee420"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee420",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee420",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee421"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee421",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee421",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee422"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee422",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee422",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee423"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee423",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee423",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee424"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee424",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee424",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee425"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee425",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee425",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee426"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee426",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee426",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee427"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee427",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee427",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee428"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee428",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee428",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee429"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee429",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee429",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee430"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee430",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee430",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee431"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee431",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee431",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee432"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee432",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee432",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee433"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee433",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee433",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee434"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee434",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee434",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee435"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee435",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee435",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee436"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee436",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee436",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee437"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee437",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee437",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee438"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee438",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee438",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee439"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee439",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee439",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee440"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee440",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee440",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee441"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee441",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee441",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee442"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee442",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee442",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee443"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee443",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee443",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee444"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee444",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee444",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee445"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee445",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee445",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee446"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee446",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee446",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee447"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee447",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee447",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee448"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee448",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee448",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee449"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee449",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee449",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "helenho"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Helen Ho",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "helenho",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 4,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "tan"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Prof Tan",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "tan",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "employee52"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee52",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee52",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee53"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee53",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee53",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee54"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee54",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee54",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee55"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee55",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee55",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee56"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee56",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee56",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee57"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee57",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee57",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee58"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee58",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee58",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee59"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee59",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee59",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee510"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee510",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee510",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "petertan"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Peter Tan Ah Meng",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "petertan",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee512"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee512",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee512",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee513"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee513",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee513",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee514"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee514",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee514",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee515"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee515",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee515",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee516"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee516",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee516",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee517"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee517",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee517",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee518"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee518",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee518",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee519"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee519",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee519",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee520"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee520",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee520",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee521"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee521",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee521",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee522"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee522",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee522",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee523"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee523",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee523",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee524"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee524",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee524",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee525"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee525",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee525",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee526"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee526",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee526",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee527"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee527",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee527",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee528"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee528",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee528",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee529"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee529",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee529",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee530"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee530",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee530",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee531"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee531",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee531",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee532"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee532",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee532",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee533"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee533",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee533",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee534"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee534",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee534",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee535"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee535",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee535",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee536"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee536",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee536",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee37"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee37",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee37",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee538"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee538",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee538",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee539"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee539",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee539",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "helenho"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Helen Ho",
                    Email = "helenho@gmail.com",
                    UserName = "helenho",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee541"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee541",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee541",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee542"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee542",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee542",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee543"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee543",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee543",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee544"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee544",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee544",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee545"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee545",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee545",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee546"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee546",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee546",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee547"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee547",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee547",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee548"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee548",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee548",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee549"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee549",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee549",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee550"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee550",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee550",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 5,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }


            if (!context.Users.Any(u => u.UserName == "samanthan"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Samantha Neo",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "samanthan",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "employee62"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee62",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee62",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee63"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee63",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee63",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee64"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee64",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee64",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee65"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee65",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee65",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee66"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee66",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee66",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee67"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee67",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee67",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee68"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee68",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee68",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee69"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee69",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee69",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee610"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee610",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee610",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee611"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee611",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee611",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee612"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee612",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee612",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee613"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee613",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee613",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee614"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee614",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee614",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee615"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee615",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee615",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee616"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee616",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee616",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee617"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee617",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee617",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee618"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee618",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee618",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee619"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee619",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee619",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 1
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee620"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee620",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee620",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee621"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee621",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee621",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee622"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee622",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee622",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee623"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee623",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee623",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee624"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee624",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee624",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "sridharan"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Sridharan Jayanthi",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "sridharan",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee626"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee626",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee626",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee627"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee627",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee627",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee628"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee628",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee628",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee629"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee629",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee629",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee630"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee630",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee630",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee631"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee631",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee631",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee632"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee632",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee632",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee633"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee633",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee633",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee634"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee634",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee634",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee635"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee635",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee635",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee636"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee636",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee636",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee637"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee637",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee637",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee638"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee638",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee638",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee639"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee639",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee639",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "helenho"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Helen Ho",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "helenho",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee641"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee641",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee641",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee642"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee642",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee642",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee643"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee643",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee643",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee44"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee644",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee644",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee645"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee645",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee645",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee646"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee646",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee646",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee647"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee647",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee647",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee648"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee648",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee648",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee649"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee649",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee649",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee650"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee650",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee650",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    DepartmentId = 6,
                    RepStatus = 0
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }






            if (!context.Users.Any(u => u.UserName == "cindy"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Cindy",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "cindy",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 1,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "hana"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Hana",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "hana",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "zap"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr ZAP",
                    Email = "storetdepteam8ad@gmail.com",
                    UserName = "zap",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "StoreClerk");
            }
            if (!context.Users.Any(u => u.UserName == "yadanar"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Yadanar",
                    Email = "storetdepteam8ad@gmail.com",
                    UserName = "yadanar",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "StoreSupervisor");
            }
            if (!context.Users.Any(u => u.UserName == "managerhana"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms managerhana",
                    Email = "storetdepteam8ad@gmail.com",
                    UserName = "managerhana",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "StoreManager");
            }

            if (!context.Users.Any(u => u.UserName == "shunyee"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Tan Shun Yee",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "shunyee",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "abdulzaidi"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Abdul Zaidi",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "abdulzaidi",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "esthertan"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm Esther Tan",
                    Email = "storetdepteam8ad@gmail.com",
                    UserName = "esthertan",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "StoreClerk");
            }


            if (!context.Users.Any(u => u.UserName == "bonnietay"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm Bonnie Tay",
                    Email = "storetdepteam8ad@gmail.com",
                    UserName = "bonnietay",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "StoreClerk");
            }
            if (!context.Users.Any(u => u.UserName == "employee710"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee710",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee710",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee711"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee711",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee711",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee712"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee712",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee712",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee713"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee713",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee713",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee714"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee714",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee714",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee715"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee715",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee715",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee716"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee716",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee716",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee717"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee717",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee717",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee718"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee718",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee718",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee719"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee719",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee719",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee720"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee720",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee720",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee721"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee721",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee721",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee722"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee722",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee722",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee723"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee723",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee723",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee724"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee724",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee724",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee725"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee725",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee725",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee726"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee726",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee726",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee727"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee727",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee727",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee728"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee728",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee728",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee729"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee729",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee729",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee730"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee730",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee730",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee731"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee731",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee731",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee732"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee732",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee732",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee733"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee733",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee733",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee734"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee734",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee734",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee35"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee735",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee735",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee736"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee736",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee736",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee737"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee737",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee737",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee738"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee738",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee738",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee739"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee739",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee739",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee740"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms Helen Ho",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee740",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee741"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee741",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee741",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee742"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee742",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee742",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee743"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee743",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee743",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee744"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee744",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee744",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee745"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee745",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee745",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee746"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee746",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee746",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee747"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee747",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee747",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee748"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee748",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee748",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee749"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee749",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee749",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee750"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee750",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee750",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 7
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }


            if (!context.Users.Any(u => u.UserName == "magdalenep"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Prof Magdalene Pek",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "magdalenep",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "employee82"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee82",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee82",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee83"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee83",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee83",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee84"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee84",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee84",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee85"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee85",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee85",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee86"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee86",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee86",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee87"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee87",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee87",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee88"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee88",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee88",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee89"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee89",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee89",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee810"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee810",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee810",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee811"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee811",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee811",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee812"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee812",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee812",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee813"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee813",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee813",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee814"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee814",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee814",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee815"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee815",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee815",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee816"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee816",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee816",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee817"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee817",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee817",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee818"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee818",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee818",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee819"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee819",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee819",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 1,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee820"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee820",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee820",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee821"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee821",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee821",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee822"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee822",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee822",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee823"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee823",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee823",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee824"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee824",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee824",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee825"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee825",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee825",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee826"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee826",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee826",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee827"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee827",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee827",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee828"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee828",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee828",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee829"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee829",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee829",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee830"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee830",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee830",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee831"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee831",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee831",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee832"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee832",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee832",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee833"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee833",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee833",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee834"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee834",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee834",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee835"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee835",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee835",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee836"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee836",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee836",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee837"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee837",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee837",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee838"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee838",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee838",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee839"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee839",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee839",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee840"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee840",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee840",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee841"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee841",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee841",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee842"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee842",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee842",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee843"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee843",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee843",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee844"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee844",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee844",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee845"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee845",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee845",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee846"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee846",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee846",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "khoocheehuat"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Khoo Chee Huat",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "khoocheehuat",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee848"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee848",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee848",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee849"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee849",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee849",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee850"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee850",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee850",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 8
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "lawrencew"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Lawrence Wong",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "lawrencew",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "lowsoochiew"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm Low Soo Chiew",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "lowsoochiew",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee93"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee93",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee93",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee94"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee94",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee94",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee95"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee95",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee95",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee96"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee96",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee96",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee97"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee97",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee97",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee98"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee98",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee98",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee99"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee99",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee99",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee910"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee910",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee910",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee911"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee911",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee911",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee912"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee912",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee912",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee913"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee913",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee913",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee914"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee914",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee914",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee915"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee915",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee915",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee916"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee916",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee916",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee917"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee917",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee917",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee918"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee918",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee918",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee919"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee919",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee919",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 1,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee920"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee920",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee920",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee921"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee921",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee921",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee922"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee922",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee922",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee923"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee923",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee923",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee924"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee924",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee924",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee925"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee925",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee925",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee926"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee926",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee926",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee927"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee927",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee927",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee928"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee928",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee928",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee929"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee929",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee929",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee930"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee930",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee930",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee931"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee931",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee931",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee932"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee932",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee932",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee933"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee933",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee933",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee934"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee934",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee934",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee935"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee935",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee935",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee936"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee936",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee936",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee937"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee937",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee937",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee938"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee938",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee938",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee939"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee939",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee939",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee940"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee940",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee940",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee941"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee941",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee941",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee942"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee942",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee942",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee943"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee943",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee943",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee944"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee944",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee944",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee945"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee945",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee945",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee946"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee946",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee946",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee947"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee947",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee947",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee948"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee948",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee948",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee949"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee949",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee949",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee950"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee950",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee950",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 9
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "liongchoon"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Tan Liong Choon",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "liongchoon",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentHead");
            }

            if (!context.Users.Any(u => u.UserName == "employee102"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee102",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee102",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    RepStatus = 0,
                    PhoneNumber = "+111111111111",
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee103"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee103",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee103",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "raymondseah"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Seah Yang Hwee Raymond",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "raymondseah",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee105"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee105",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee105",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee106"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee106",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee106",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee107"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee107",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee107",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee108"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee108",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee108",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee109"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee109",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee109",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1010"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee1010",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1010",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1011"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1011",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1011",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1012"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1012",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1012",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1013"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1013",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1013",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1014"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1014",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1014",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1015"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1015",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1015",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1016"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1016",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1016",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1017"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee1017",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1017",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1018"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1018",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1018",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1019"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1019",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1019",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 1,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "DepartmentRep");
            }
            if (!context.Users.Any(u => u.UserName == "employee1020"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee1020",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1020",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1021"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1021",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1021",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1022"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1022",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1022",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1023"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1023",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1023",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1024"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1024",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1024",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1025"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs employee1025",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1025",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1026"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1026",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1026",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1027"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee1027",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1027",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1028"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr Employee1028",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1028",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1029"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee1029",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1029",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1030"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Miss Employee1030",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1030",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1031"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1031",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1031",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1032"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1032",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1032",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1033"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1033",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1033",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1034"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1034",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1034",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1035"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1035",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1035",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1036"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1036",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1036",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1037"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Ms employee1037",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1037",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1038"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1038",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1038",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1039"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1039",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1039",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1040"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "employee1040",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1040",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1041"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1041",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1041",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1042"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1042",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1042",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1043"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1043",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1043",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1044"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1044",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1044",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1045"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mdm employee1045",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1045",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1046"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1046",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1046",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1047"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1047",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1047",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }
            if (!context.Users.Any(u => u.UserName == "employee1048"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mr employee1048",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1048",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1049"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee1049",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1049",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "employee1050"))
            {
                var user = new EmployeeModel
                {
                    EmployeeName = "Mrs Employee1050",
                    Email = "departmentteam8ad@gmail.com",
                    UserName = "employee1050",
                    Password = "P@ssw0rd1",
                    ConfirmPassword = "P@ssw0rd1",
                    PhoneNumber = "+111111111111",
                    RepStatus = 0,
                    DepartmentId = 10
                };
                await userManager.CreateAsync(user, user.Password);
                await userManager.AddToRoleAsync(user.Id, "Employee");
            }


            context.SaveChanges();
        }
    }
}
