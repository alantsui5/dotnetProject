# ASP.NET Project Showcase

<p align="center">
    <img src="assets/project.png" alt="Project Image" width="300px" />
</p>

__ASP.NET Project Showcase__ is a meta-repository showcasing several systems built up with __C# ASP.NET__. They are:

1. [Pizza Inventory Management UI](#1-pizza-inventory-management-ui) -- [RazarPagesPizza](RazarPagesPizza)
2. [Pizza Inventory Management API](#2-pizza-inventory-management-api) -- [ContosoPizza](ContosoPizza)


## Project Showcase

### [1. Pizza Inventory Management API](ContosoPizza)
#### Project Nature
API backend + Non-Presistent storage + File Storage(SQLite)
#### Main Features
- Allow user to do different operation with Swagger UI and API. Operations include
    - Get pizza inventory and inventory list store
    - Add pizza inventory
    - Delete pizza in inventory for pizza served
    - Modify pizza attribute in inventory {All attribute are editable}
- Pizza will have following attributes
    - Pizza Name
    - Is Glucan Free or not {True, False}
    - Pizza Size {Small, Medium, Large}
    - Price {Numbers}
    - Pizza Source (Custom Data Structure)
    - Pizza Toppings (Custom Data Structure)
- Pizza Sauces will have following attributes
    - Sauce Name
    - Is Vegitables or not
- Pizza Toppings will have following attributes
    - Topping Name
    - Calories

### [2. Pizza Inventory Management UI](RazarPagesPizza)
#### Project Nature
UI + backend + Non-Presistent storage
#### Main Features
- Allow user to do different operation with web UI, operations are
    - Get pizza inventory store
    - Add pizza inventory with following attributes
    - Delete pizza in inventory for pizza served
    - Modify pizza attribute in inventory {All attribute are editable}
- Pizza will have following attributes
    - Pizza Name
    - Is Glucan Free or not {True, False}
    - Pizza Size {Small, Medium, Large}
    - Price {Numbers}


