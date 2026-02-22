### Endpoints
- Create template
- Get all templates for current user
- Get template by id with all questions
- Update template general info
- Delete template
- Add question
- Edit question
- Delete question

### Domain models
- TestTemplate:
Id, Name, Description, CreatedBy, Questions, Duration, EnableAutomaticMarking

- Question: Id, QuestionType, TestTemplate, QuestionText, MaxMark

### Question types
QuestionType: OpenAnswer, SingleAnswer, MultipleAnswers, CodeQuestion, DiagramQuestion.

OpenAnswer: -

SingleAnswer: AnswerVariants, RightAnswer

MultipleAnswers: AnswerVariants, RightAnswers

CodeQuestion: -

DiagramQuestion: -

For create/update operatioins: we keep the certain type of the question untill saving it to db.
For get operations, we retreive the questions in the form of JSON and convert them only on the frontend part. This is done to reduce logic related to conversion to the concrete type and can be done because we do not perform anything questiontype-sensitive during get operations.

### Description
Stores information about test templates. Responsible for CRUD operations with test templates, questions in it.

### Analysis
Service does not nesessary need to be fast, does not work with a large data, is not under high load. The DB choice will be MS SQL (provides data consistency), MinIO (self-hosted Blob storage for files, which can be easily switched to Amazon S3 later)

### Tech Stack
Language: C#
Architecture: DDD, CQRS (Logical implementation with single DB)
Database: MS SQL
File storage: MinIO (temporary)