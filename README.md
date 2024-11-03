<body>

<h1>Courses API 🧑‍🎓</h1>
<p>This API is part of the e-learning microservice and is responsible for course management on the platform. Its main features include CRUD operations for Courses, Modules, and Lessons, with specific permissions based on user roles.</p>

<h2>Security 👮‍♂️</h2>
<p>Security was a top priority in the development of this API. We implemented best security practices, including authentication via <strong>JWT</strong> to ensure that only authenticated users can access the endpoints.</p>

<h2>Endpoints</h2>

<img src="https://github.com/user-attachments/assets/88712ed5-8b3e-474f-ad47-d644df8df6e0" alt="API Endpoints Image">


<h3>Courses</h3>
<ul>
  <li><strong>GET /api/v1/courses</strong> - Returns a paginated list of courses. Requires query params <code>pageNumber</code> and <code>pageSize</code>. (Role: Premium)</li>
  <li><strong>POST /api/v1/courses</strong> - Creates a new course. (Role: Admin)</li>
  <li><strong>GET /api/v1/courses/{id}</strong> - Returns a specific course. (Role: Premium)</li>
  <li><strong>PUT /api/v1/courses/{id}</strong> - Updates a specific course. (Role: Admin)</li>
  <li><strong>DELETE /api/v1/courses/{id}</strong> - Deletes a specific course. (Role: Admin)</li>
</ul>

<h3>Modules</h3>
<ul>
  <li><strong>GET /api/v1/modules/{id}</strong> - Returns a specific module. (Role: Premium)</li>
  <li><strong>POST /api/v1/modules</strong> - Creates a new module. (Role: Admin)</li>
  <li><strong>PUT /api/v1/modules/{id}</strong> - Updates a specific module. (Role: Admin)</li>
  <li><strong>DELETE /api/v1/modules/{id}</strong> - Deletes a specific module. (Role: Admin)</li>
</ul>

<h3>Lessons</h3>
<ul>
  <li><strong>GET /api/v1/lessons/{id}</strong> - Returns a specific lesson. (Role: Premium)</li>
  <li><strong>POST /api/v1/lessons</strong> - Creates a new lesson. (Role: Admin)</li>
</ul>

<h2>Authentication and Authorization</h2>
<p>Creation, update, and deletion operations are restricted to users with the <strong>Admin</strong> role, while course viewing is allowed only for users with the <strong>Premium</strong> role.</p>

<h2>Architecture and Technologies</h2>
<p>The API follows Domain-Driven Design (DDD) standards and is organized into three main layers: API, Core, and Data. Unlike other APIs in the microservice, this one uses <strong>Services</strong> instead of CQRS for responsibility separation.</p>

<img src="https://github.com/user-attachments/assets/019b7173-976e-4e8a-aa51-b1e93153d4c9" alt="Architecture Image">

</body>
