### Endpoints
- Create profile
- Update profile
- Create students group
- Delete students group
- Update general students group info
- Get all students groups for user
- Get students group by id
- Add student to students group
- Remove student from students group

### Domain models
- Profile: userID, first name, last name, email
- StudentsGroup: groupID, group name, description, students, createdBy

### Description
Stores public profiles info of users and user groups

### Analysis
Low-medium load, does not required high response speed. Gonna use simple 

### Tech Stack
Language: C#
Architecture: DDD
Database: MS SQL