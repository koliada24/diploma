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
1) Account Service (account creation, login, logout, store accounts info)
2) Templates Service (CRUD test templates, question, store test templates info)
3) Test proceccing service (for active tests: temporary stores info about student answers until test is finished, after finishing sends answer to the )
4) Tests store service (stores information about finished tests)
