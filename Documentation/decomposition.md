### Use cases

- As ***examinator*** I want to create ***accounts***
- As ***examinator*** I want to use ***accounts***
- As ***examinator*** I want to create ***test templates***
- As ***examinator*** I want to list ***test templates***
- As ***examinator*** I want to delete ***test templates***
- As ***examinator*** I want to edit ***test templates***
- As ***examinator*** I want to add ***questions*** to ***test templates***
- As ***examinator*** I want to list ***questions*** in ***test templates***
- As ***examinator*** I want to edit ***questions*** in ***test templates***
- As ***examinator*** I want to delete ***questions*** from ***test templates***
- As ***examinator*** I want to create student ***accounts***
- As ***examinator*** I want to administer ***tests*** created from ***test templates***
- As ***examinator*** I want to list all the ***tests*** created from ***test templates***
- As ***examinator*** I want to evaluate the ***tests*** created from ***test templates***
- As ***student*** I want to create ***accounts***
- As ***student*** I want to use ***accounts***
- As ***student*** I want to list ***tests*** I am enrolled to
- As ***student*** I want to take ***tests*** I am enrolled to
- As ***student*** I want to answer ***questions*** in the ***tests*** I am enrolled to
- As ***student*** I want to finish ***tests*** I took

### Decomposition
1) Authentication Service
1) User Profiles service
2) Tests Templates Service
3) Tests Proceccing service
4) Tests store service

### Authentication Service
Auth (login, logout, refresh, register)
Stores credentials (userIDs, logins, password hashes), issues tokens 

### User Profiles service
Public Profiles (listUsers, updateUsers, deleteUsers)

### Tests Templates Service
Stores information about test templates. Responsible for CRUD operations with test templates, questions in it.

### Tests Proceccing service
Temporaly stores answers of tests that are currently taken by the students. Potentially the most loaded service. Saves files of the answers for some type of questions (code questions, diagram questions). Need to be fast

### Tests store service
Contains data about all the taken tests, results. Works with a huge amount of data.