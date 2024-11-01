<body>

<h1>Courses API 🧑‍🎓</h1>
<p>Esta API faz parte do microsserviço de e-learning e é responsável pelo gerenciamento de cursos na plataforma. Suas principais funcionalidades incluem operações de CRUD para Courses, Modules e Lessons, com permissões específicas baseadas em roles de usuário.</p>

   <h2>Segurança 👮‍♂️</h2>
    <p>A segurança foi uma prioridade máxima no desenvolvimento desta API. Utilizamos as melhores práticas de segurança, incluindo a autenticação via <strong>JWT</strong> para garantir que apenas usuários autenticados possam acessar os endpoints.</p>
<h2>Endpoints</h2>

![image](https://github.com/user-attachments/assets/88712ed5-8b3e-474f-ad47-d644df8df6e0)

<h3>Courses</h3>
<ul>
  <li><strong>GET /api/v1/courses</strong> - Retorna a lista de cursos de forma paginada. Requer query params <code>pageNumber</code> e <code>pageSize</code>. (Role: Premium)</li>
  <li><strong>POST /api/v1/courses</strong> - Cria um novo curso. (Role: Admin)</li>
  <li><strong>GET /api/v1/courses/{id}</strong> - Retorna um curso específico. (Role: Premium)</li>
  <li><strong>PUT /api/v1/courses/{id}</strong> - Atualiza um curso específico. (Role: Admin)</li>
  <li><strong>DELETE /api/v1/courses/{id}</strong> - Exclui um curso específico. (Role: Admin)</li>
</ul>

<h3>Modules</h3>
<ul>
  <li><strong>GET /api/v1/modules/{id}</strong> - Retorna um módulo específico. (Role: Premium)</li>
  <li><strong>POST /api/v1/modules</strong> - Cria um novo módulo. (Role: Admin)</li>
  <li><strong>PUT /api/v1/modules/{id}</strong> - Atualiza um módulo específico. (Role: Admin)</li>
  <li><strong>DELETE /api/v1/modules/{id}</strong> - Exclui um módulo específico. (Role: Admin)</li>
</ul>

<h3>Lessons</h3>
<ul>
  <li><strong>GET /api/v1/lessons/{id}</strong> - Retorna uma aula específica. (Role: Premium)</li>
  <li><strong>POST /api/v1/lessons</strong> - Cria uma nova aula. (Role: Admin)</li>
</ul>

<h2>Autenticação e Autorização</h2>
<p>As operações de criação, atualização e exclusão são restritas a usuários com a role <strong>Admin</strong>, enquanto a visualização de cursos é permitida apenas para usuários com a role <strong>Premium</strong>.</p>

<h2>Arquitetura e Tecnologias</h2>
<p>A API segue os padrões de Domain-Driven Design (DDD) e está organizada em três camadas principais: API, Core e Data. Diferente de outras APIs do microsserviço, esta utiliza <strong>Services</strong> ao invés de CQRS para a separação de responsabilidades.</p>

![image](https://github.com/user-attachments/assets/019b7173-976e-4e8a-aa51-b1e93153d4c9)

</body>
