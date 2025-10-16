# 🚀 EF Core Methods - Single-Layer Example Project

This project is designed to help you *understand and apply* Entity Framework Core methods in a single-layer architecture.  
It demonstrates approximately *70 different EF Core and LINQ methods* with real-world usage scenarios. 🎯

---

## 📦 Entity Classes Used

The project includes the following entities:

- 🏃‍♂ **Activity**  
- 📂 **Category**  
- 🙋‍♂ **Customer**  
- 💬 **Message**  
- 🛒 **Order**  
- 📦 **Product**  
- 📝 **ToDo**

Each entity represents a database table and is used for CRUD operations and queries through EF Core.

---

## ⚙ LINQ & EF Core Methods in the Project – Explanation and Real-World Use Cases

### 🔹 Basic CRUD Operations

| Method             | Description                                     | Real-World Use Case                                                     |
| -----------------  | ----------------------------------------------- | ---------------------------------------------------------------------- |
| Add()              | Adds a new object to the DbContext.            | Adding a new record from a form: `context.Users.Add(user);`           |
| AddAsync()         | Adds a new object asynchronously.               | Async form submission: `await context.Users.AddAsync(user);`          |
| AddRange()         | Adds multiple objects at once.                  | Bulk user creation: `context.Users.AddRange(userList);`               |
| AddRangeAsync()    | Adds multiple objects asynchronously.           | Async bulk insert: `await context.Users.AddRangeAsync(userList);`     |
| Update()           | Updates an existing object.                     | Updating a user profile: `context.Users.Update(user);`                |
| Remove()           | Deletes an existing object.                     | Admin panel record deletion: `context.Users.Remove(user);`            |
| SaveChanges()      | Saves all changes to the database.             | After adding, updating, or deleting data: `context.SaveChanges();`    |
| SaveChangesAsync() | Saves changes asynchronously.                   | `await context.SaveChangesAsync();`                                    |
| Find()             | Quickly searches by primary key.               | Getting details for a product page: `var product = context.Products.Find(id);` |
| FindAsync()        | Async version of Find() by primary key.        | `var user = await context.Users.FindAsync(id);`                        |

---

### 🔹 Data Listing & Transformation

| Method           | Description                                   | Real-World Use Case                                                     |
| ---------------- | --------------------------------------------- | ---------------------------------------------------------------------- |
| ToList()         | Executes the query and converts the result to a list. | Retrieve all users: `var users = context.Users.ToList();`              |
| ToListAsync()    | Converts query results to a list asynchronously. | Fetch data in an API: `await context.Users.ToListAsync();`             |
| Select()         | Projects or transforms data.                  | Get only usernames: `users.Select(u => u.UserName);`                   |
| Include()        | Includes related data in the query.          | Fetch orders along with customer info: `context.Orders.Include(o => o.Customer);` |
| AsNoTracking()   | Improves performance for read-only queries.  | Read-only lists: `context.Users.AsNoTracking().ToList();`               |

---

### 🔹 Filtering & Querying

| Method             | Description                                             | Real-World Use Case                                                |
| ------------------ | ------------------------------------------------------- | ----------------------------------------------------------------- |
| Where()            | Filters data based on a condition.                     | List users from a specific city: `users.Where(u => u.City == "Izmir");` |
| FirstOrDefault()   | Returns the first match or default if none found.      | Find logged-in user: `context.Users.FirstOrDefault(u => u.Email == email);` |
| All()              | Checks if all elements satisfy a condition.           | Are all users active? `users.All(u => u.IsActive);`               |
| Any()              | Checks if any element satisfies a condition.          | Check if email exists: `users.Any(u => u.Email == email);`        |
| AnyAsync()         | Async version of Any().                                | `await context.Users.AnyAsync(u => u.IsActive);`                  |
| AllAsync()         | Async version of All().                                | `await context.Users.AllAsync(u => u.IsVerified);`                |
| Contains()         | Checks if a value exists in a collection or string.   | Does the name contain "Ali"? `name.Contains("Ali");`              |
| StartsWith()       | Checks if a string starts with a specific value.      | Does phone start with "+90"? `phone.StartsWith("+90");`           |
| EndsWith()         | Checks if a string ends with a specific value.        | Is the file a ".jpg"? `file.EndsWith(".jpg");`                    |
| DefaultIfEmpty()   | Returns a default value if the collection is empty.   | Fallback for empty lists: `query.DefaultIfEmpty(new Product());`   |

---

### 🔹 Ordering & Pagination

| Method                 | Description                            | Real-World Use Case                                                   |
| ---------------------- | -------------------------------------- | -------------------------------------------------------------------- |
| Take()                 | Takes the first N elements.            | Pagination: get first 10 records: `products.Take(10);`               |
| Skip()                 | Skips the first N elements.            | Pagination: go to page 2: `products.Skip(10).Take(10);`              |
| OrderBy()              | Sorts ascending.                       | Sort users by name: `users.OrderBy(u => u.Name);`                    |
| OrderByDescending()    | Sorts descending.                      | Sort orders by date: `orders.OrderByDescending(o => o.Date);`       |
| SkipLast()             | Skips the last N elements.             | Exclude last 3 records: `list.SkipLast(3);`                          |
| TakeLast()             | Takes the last N elements.             | Get last 5 logs: `logs.TakeLast(5);`                                  |
| Reverse()              | Reverses a collection.                 | Display a list in reverse order: `items.Reverse();`                   |

---

### 🔹 Set & Collection Operations

| Method       | Description                                         | Real-World Use Case                                                   |
| ------------ | --------------------------------------------------- | -------------------------------------------------------------------- |
| Concat()     | Concatenates two collections sequentially.         | Merge users and admins: `users.Concat(admins);`                      |
| Union()      | Combines collections without duplicates.           | Merge users from two cities: `users1.Union(users2);`                 |
| UnionBy()    | Combines collections uniquely by a key.            | Unique users by email: `users1.UnionBy(users2, u => u.Email);`       |
| Except()     | Returns elements in one collection but not in another. | Exclude banned users: `allUsers.Except(bannedUsers);`              |
| ExceptBy()   | Excludes by a specific property.                   | `ExceptBy(admins, u => u.Email);`                                     |
| Intersect()  | Returns common elements between collections.       | Find common customers: `list1.Intersect(list2);`                     |
| Distinct()   | Removes duplicate elements.                         | Filter duplicate names: `names.Distinct();`                          |
| Append()     | Adds an element to the end of a collection.        | Add item to a list: `list.Append(newItem);`                           |
| Prepend()    | Adds an element to the start of a collection.      | Add main menu: `menu.Prepend("Home");`                                |
| Chunk()      | Splits a collection into chunks.                    | Pagination convenience: `list.Chunk(10);`                             |

---

### 🔹 Advanced & Other Methods

| Method             | Description                                                        | Real-World Use Case                                                     |
| -----------------  | ------------------------------------------------------------------ | ---------------------------------------------------------------------- |
| Aggregate()         | Performs a cumulative operation on a collection.                  | Calculate total length: `list.Aggregate((a, b) => a + b);`             |
| GroupBy()           | Groups elements by a key.                                          | Group users by city: `users.GroupBy(u => u.City);`                     |
| Join()              | Joins two collections on a key.                                    | Combine user and address info.                                         |
| GroupJoin()         | Performs grouped joins.                                            | Fetch categories and their products.                                   |
| AsQueryable()       | Converts IEnumerable to IQueryable.                                | Create dynamic queries: `list.AsQueryable();`                           |
| Entry()             | Gets the EF tracking state of an entity.                           | Check entity state: `context.Entry(user).State;`                        |
| Cast<T>()           | Casts a collection to a specific type.                             | Convert object list to int list: `list.Cast<int>();`                    |
| OfType<T>()         | Filters elements by type.                                          | Get only string values: `list.OfType<string>();`                        |
| Attach()            | Attaches an untracked entity to the context.                       | Update external entity: `context.Attach(entity);`                       |
| AttachRange()       | Attaches multiple entities.                                        | Bulk update scenarios.                                                 |
| ElementAt()         | Gets the element at a specific index.                               | Used in special scenarios instead of `list[index]`.                    |
| CountBy()           | Counts elements by a key (requires LinqKit or MoreLinq).           | Count users per city: `users.CountBy(u => u.City);`                     |
| LongCount()         | Returns count for very large collections.                           | Count elements in huge datasets: `users.LongCount();`                   |
| SingleOrDefault()   | Returns the single element matching a condition or default.        | Unique user check: `context.Users.SingleOrDefault(u => u.Id == id);`    |
| First()             | Returns the first element or throws an exception if empty.         | Get the latest user: `users.OrderByDescending(u => u.Id).First();`      |
| Last()              | Returns the last element or throws an exception if empty.          | Perform action on the last item: `list.Last();`                         |

---

This README provides a comprehensive reference for using EF Core and LINQ methods in real-world single-layer projects, helping developers implement efficient and readable data operations. ✅

---

# Screenshots
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104522" src="https://github.com/user-attachments/assets/f37c4e32-ac0b-42ee-9a26-1e65dac66621" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104513" src="https://github.com/user-attachments/assets/91add315-3cc7-4d74-af33-d2023de4900d" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104459" src="https://github.com/user-attachments/assets/8957248a-e3bb-4c82-a3c5-a871bdc505e9" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104455" src="https://github.com/user-attachments/assets/751d8089-eb19-4e29-a8fb-eb3d17aa464e" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104450" src="https://github.com/user-attachments/assets/f8c0a48e-e525-42bd-9162-24069f1d325b" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104443" src="https://github.com/user-attachments/assets/6396368b-f9dc-45df-bc3c-6909d98dabc8" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104411" src="https://github.com/user-attachments/assets/8d5dbdec-efd2-4320-94d1-d5f88abee800" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104406" src="https://github.com/user-attachments/assets/17c5d135-d2cc-4fcb-94b0-effc37080de3" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104354" src="https://github.com/user-attachments/assets/00d122d2-9625-4513-8f93-2269cef02872" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104348" src="https://github.com/user-attachments/assets/450d8ff2-9bd8-4747-bd33-13712fcd7a38" />
<img width="1918" height="526" alt="Screenshot 2025-10-16 104342" src="https://github.com/user-attachments/assets/7a81ff50-3fca-4859-ab3f-1c874a1d6baa" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104325" src="https://github.com/user-attachments/assets/d1b43b4f-b0b9-4aca-aeba-58965b49cf31" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104305" src="https://github.com/user-attachments/assets/22675940-8e7d-4fe3-9479-41ae17d70de5" />
<img width="1919" height="1079" alt="Screenshot 2025-10-16 104249" src="https://github.com/user-attachments/assets/36d7453e-e5a5-4d71-a405-04912b77d35f" />
<img width="315" height="1079" alt="Screenshot 2025-10-16 104640" src="https://github.com/user-attachments/assets/e39a4e6c-d4fc-41a2-9ee8-81b15316bd15" />

