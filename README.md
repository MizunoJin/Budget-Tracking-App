# Budget Tracking App

## Implementation

In implementation, the following points were taken into account while paying attention to maintainability and extensibility

### Design Patterns

#### Singleton Pattern

The Singleton pattern ensures that a class has only one instance and provides a global point of access to it. In this application, the `Logger` and `BudgetApp` classes utilize the Singleton pattern. These classes hold their instances statically and offer access to the unique instance through a `GetInstance()` method, preventing direct instantiation from outside. This pattern is beneficial for maintaining a consistent logging mechanism and managing core functionalities of the application across its entirety.

#### Factory Pattern

The Factory Pattern separates the instantiation logic from the client and allows subclasses to decide what to instantiate. The CategoryFactory class in this case is responsible for generating different types of category objects (PresetCategory and UserCategory). Each method creates a new category object of the requested type, assigns it a unique ID (CategoryId), sets the required information (name and user) and then returns the object. This allows categories to be uniquely identified throughout the application.

#### Repository Pattern (Bridge Pattern)

The Repository pattern introduces an abstraction layer between the data source (e.g., a database) and the business logic layer. It separates data access logic from business logic, allowing for changes in data sources without impacting the business logic. The `Logger` class adopts this pattern, interfacing with log storage through the `ILogRepository` interface, enabling flexible changes in log storage destinations. This facilitates easy switching between different logging methods for development and production environments.

### Inheritance

In managing categories, the application distinguishes between two types: categories created by the user (User Categories) and categories pre-defined by the application (Preset Categories). To efficiently manage these categories, an abstract class named `Category` consolidates common attributes. This class is then inherited by `PresetCategory` and `UserCategory` to cater to their specific needs.

- **UserCategory** needs to be linked with a `User`, hence an additional `User` attribute is incorporated to establish a clear relationship between the user and their categories.
- **PresetCategory** requires the instances created to be shared across all users of the application. To fulfill this requirement, static attributes within the PresetCategory class manage the instances, ensuring application-wide accessibility.

### Delegation

The `CalcSpent` method in the `User` class calculates spending for a user in a specific category, based on the category and transaction list. Here, a `User` object calculates expenditure through its transaction list for a given category, bearing the responsibility of deriving expenditures by category. This can be considered delegation in terms of distributing responsibilities among objects.

### Special Notes

- **Static Instance Management in PresetCategory**: The `PresetCategory` class manages all instances using a static list to track created instances. This facilitates easy access to preset category instances across the application while tracking each new instance as it's created.
- **Use Cases as Service Layer**: As the program expanded and the `Program.cs` file became lengthy and cluttered, files were segmented according to domain areas and stored within the `Services` directory. This reorganization improved code structure and manageability.
- **Defining Methods within Models**: Operations tied to a specific model and called multiple times within the service layer are defined as methods within the model itself. For example, the operation to retrieve all categories of a user is defined as the `GetCategories` method within the `User` model. This approach enhances code reusability and organization.
- **Transaction Management**: Transactions are categorized into two types: Expenses and Income. These categories are managed through an Enum named `TransactionType`, with attributes defined as `Type` within transactions. This distinction clarifies transaction types, simplifying their management.
