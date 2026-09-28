# Apartment API

គម្រោង Apartment API នេះគឺជាប្រព័ន្ធខាងក្រោយ (Backend API) ដែលត្រូវបានបង្កើតឡើងដើម្បីគ្រប់គ្រងទិន្នន័យទូទៅរបស់អាផាតមិន (Apartment) រួមមាន ការគ្រប់គ្រងអគារ បន្ទប់ បុគ្គលិក អតិថិជន ការចំណាយ និងប្រព័ន្ធសុវត្ថិភាព (Authentication)។

## 🛠 បច្ចេកវិទ្យាដែលបានប្រើប្រាស់ (Technologies & Tools)

គម្រោងនេះត្រូវបានបង្កើតឡើងដោយប្រើប្រាស់បច្ចេកវិទ្យា និង Library ដូចខាងក្រោម៖

*   **Framework:** .NET 8.0 (ASP.NET Core Web API)
*   **Database ORM:** Entity Framework Core 8
*   **Database Provider:** Oracle Database (`Oracle.EntityFrameworkCore`)
*   **Authentication & Security:** JWT (JSON Web Token) សម្រាប់ការផ្ទៀងផ្ទាត់ (`Microsoft.AspNetCore.Authentication.JwtBearer`)
*   **Object Mapping:** AutoMapper សម្រាប់បំប្លែងទិន្នន័យរវាង Models និង DTOs
*   **API Documentation:** Swagger / OpenAPI (`Swashbuckle.AspNetCore`) សម្រាប់មើល និងតេស្ត API Endpoints
*   **JSON Serialization:** Newtonsoft.Json

## 🚀 មុខងារគោលនៃគម្រោង (Main Features / Controllers)

ប្រព័ន្ធនេះមានមុខងារ (Functions/Endpoints) ជាលក្ខណៈ CRUD (Create, Read, Update, Delete) រួមមានទាំងការទាញយកទិន្នន័យជាលក្ខណៈទំព័រ (Pagination) ដែលត្រូវបានបែងចែកជាផ្នែកៗដូចខាងក្រោម៖

### 1. ការគ្រប់គ្រងអ្នកប្រើប្រាស់ និងសិទ្ធិ (Users & Authentication)
*   **AuthController:** សម្រាប់អ្នកប្រើប្រាស់ Login ដើម្បីទទួលបាន Token (JWT)។
*   **UserController:** សម្រាប់គ្រប់គ្រងគណនីអ្នកប្រើប្រាស់ (បង្កើត កែប្រែ លុប ឬទាញយកទិន្នន័យ)។
*   **RoleController & UserRolesController:** សម្រាប់បង្កើត តួនាទី (Roles) និងកំណត់សិទ្ធិឱ្យអ្នកប្រើប្រាស់។

### 2. ការគ្រប់គ្រងទិន្នន័យអាផាតមិន (Apartment Management)
*   **BuildingController:** គ្រប់គ្រងអគារ។
*   **FloorsController:** គ្រប់គ្រងជាន់នៃអគារនីមួយៗ។
*   **RoomTypeController:** គ្រប់គ្រងប្រភេទបន្ទប់ (ឧទាហរណ៍៖ បន្ទប់ Standard, VIP, ល)។
*   **ItemController:** គ្រប់គ្រងសម្ភារៈប្រើប្រាស់ផ្សេងៗ។

### 3. ការគ្រប់គ្រងអតិថិជន និងអ្នកស្នាក់នៅ (Customer & Guest)
*   **CustomerController:** គ្រប់គ្រងព័ត៌មានអតិថិជនដែលជួលបន្ទប់។
*   **GuestController:** គ្រប់គ្រងព័ត៌មានភ្ញៀវ ឬអ្នកដែលមកស្នាក់នៅជាមួយ។

### 4. ការគ្រប់គ្រងបុគ្គលិក និងប្រាក់បៀវត្ស (Staff & Payroll)
*   **StaffController:** គ្រប់គ្រងទិន្នន័យផ្ទាល់ខ្លួនរបស់បុគ្គលិក។
*   **PositionController:** គ្រប់គ្រងមុខតំណែងរបស់បុគ្គលិក។
*   **SalaryController:** គ្រប់គ្រងប្រាក់ខែគោលរបស់បុគ្គលិក។
*   **PayslipController:** គ្រប់គ្រងប័ណ្ណបើកប្រាក់ខែ (ការគិតប្រាក់ខែជាក់ស្ដែង)។

### 5. ការគ្រប់គ្រងការចំណាយ (Expense Management)
*   **ExpensTypeController:** គ្រប់គ្រងប្រភេទនៃការចំណាយផ្សេងៗ។
*   **OrtherExpensController:** កត់ត្រាការចំណាយផ្សេងៗប្រចាំថ្ងៃ ឬប្រចាំខែ។

## 📂 រចនាសម្ព័ន្ធកូដ (Project Architecture)

គម្រោងនេះត្រូវបានរៀបចំឡើងទៅតាមទម្រង់ Repository Pattern ឬ N-Tier Architecture ដែលរួមមាន៖
*   **Controllers:** សម្រាប់ទទួល HTTP Requests ពី Client និងបញ្ជូន Responses ត្រលប់ទៅវិញ។
*   **Services:** ជាកន្លែងសរសេរ Business Logic។
*   **Repositories:** ជាកន្លែងសម្រាប់ទាក់ទងដោយផ្ទាល់ជាមួយ Database តាមរយៈ Entity Framework។
*   **Models / Entities:** ជា Classes ដែលតំណាងឱ្យតារាង (Tables) នៅក្នុង Database។
*   **DTOs (Data Transfer Objects):** សម្រាប់ត្រងទិន្នន័យ (Request/Response) ដើម្បីកុំឱ្យបញ្ចេញទិន្នន័យ Models ផ្ទាល់។
*   **Middlewares & Helpers:** សម្រាប់គ្រប់គ្រងការ Exceptions នានា និងជំនួយក្នុងការសរសេរកូដ (Custom Responses)។
