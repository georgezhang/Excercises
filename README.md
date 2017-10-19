**This project is intended to be an excercise for SQL Trainning group to learn the relationship between application and database.**

# Videos

## Chinese 中文
<a href="http://www.youtube.com/watch?feature=player_embedded&v=NtGRqajrjfY
" target="_blank"><img src="http://img.youtube.com/vi/NtGRqajrjfY/default.jpg" 
alt="Project Excercise Development Environment Setup" width="240" height="180" border="10" /></a>

# Requirements

This project is to build an online exam service that user can create their own exam series with question and answer. 

- User performs signup and login with user email and password
- User creates exam, adds multiple questions with choice answers
- User shares its exam to students through URL, Social medias
- Student will access the exam and take exam with his/her own account
- The student will get scores. Optionally the student can review the mistakes with correct answers


# Infrastructure
This is a .net MVC project connected to database remotely with SQL authentication. This service will implement on IIS web server. 

# Development Stages
1. Bronze
  * UI Design, user login, logout and signup
  * We use Entity Framework Database First to map tables/views to our codes
  * Create new/update/delete Exam and its questions
  * User's dashboard shows reports of student's score
2. Silver
  * 
3. Gold
