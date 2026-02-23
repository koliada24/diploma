# Tests Proceccing Service

### Description
Temporaly stores answers of tests that are currently taken by the students. Potentially the most loaded service. Saves files of the answers for some type of questions (code questions, diagram questions). Need to be fast.

### Endpoints
- Start test (as teacher)
- Take test (as student)
- Finish test
- Save answer
- Get list of running tests for teacher
- Get list of running tests for student

### Domain models
- RunningTest
TestId, Answers, FinishTime, StudentId

### Analysis
High load, need to be fast, temporary storage

### Tech Stack
Language: C#

Architecture: DDD

Database: Redis