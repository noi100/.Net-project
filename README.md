# Inventory & Store Management System

A comprehensive management system that allows administrators to efficiently and securely control store data, including customers, products, and sales/promotions. The project is developed in **C#** and demonstrates a modern layered software architecture, ensuring a complete separation of concerns between the user interface and the business logic.

## 🚀 Key Features
* **Customer Management:** Add, update, delete (with safety validation), and search customers with dynamic real-time filtering.
* **Product Management:** Inventory tracking, barcode-based product deletion, and human-error prevention.
* **Sales & Promotions Management:** Define date-bound promotions, set minimum quantity requirements, restrict to club members only, and search dynamically by sale ID.
* **Safe User Experience:** Uses confirmation dialogs (`MessageBox`) before irreversible deletions, and robust data validation before saving.

---

## 🏗️ Architecture & Clean Code
The system is built using a classic **N-Tier (Layered) Architecture**, cleanly separating different responsibilities across the application:

1. **UI (User Interface Layer):** Built with Windows Forms (WinForms). Responsible for user interaction, input collection, event handling, and data visualization via `DataGridView`.
2. **BL (Business Logic Layer):** The "brain" of the application. This layer enforces all business rules, performs calculations, handles validation logic (e.g., preventing the deletion of a customer with active orders), and mediates between the UI and the data source.
3. **BO (Business Objects Layer):** Defines the system domain entities (`Customer`, `Product`, `Sale`). These objects act as standard data carriers across the different layers.

### 🧩 Design Patterns Applied
* **Factory Pattern:** The UI layer remains decoupled from the concrete implementation of the business logic. Instead, it interacts with the logic layer strictly via Interfaces resolved by calling `BlApi.Factory.Get()`.
* **LINQ & Projections:** Heavy use of LINQ for dynamic runtime filtering and custom object projections directly into data tables.

---

## 🛠️ Tech Stack
* **Language:** C# (.NET Framework / .NET Core)
* **Framework:** Windows Forms (WinForms)
* **Data Manipulation:** LINQ (Language Integrated Query)
* **Version Control:** Git & GitHub

---

## 📂 Project Structure
├── UI/                  # Presentation Layer (Forms, control events, and UI logic)
│   ├── CustomerForm.cs  # Form for adding, updating, and deleting customers
│   ├── SaleForm.cs      # Form for sales and promotions management
│   └── ...
├── BL/                  # Business Logic Layer & Interfaces (The "Brain")
├── DAL/                 # Data Access Layer (Handles XML, DB, or Memory storage)
│   ├── DalApi/          # Interfaces defining data operations
│   ├── DalXml/          # XML-based data persistence (if used)
│   └── DalList/         # In-memory list storage (if used)
├── BO/                  # Business Objects (Domain entities definition)
└── README.md            # Main documentation file
