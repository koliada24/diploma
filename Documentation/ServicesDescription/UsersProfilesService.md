# Users Profiles Service

### Description
Stores public profiles info of users and user groups

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

### Analysis
No obvious critical condinitons, using default stack

### Tech Stack
Language: C#

Architecture: DDD

Database: MS SQL