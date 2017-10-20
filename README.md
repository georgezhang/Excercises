**This project is intended to be an excercise for SQL Trainning group to learn the relationship between application and database.**

## Videos

### English
<a href="http://www.youtube.com/watch?feature=player_embedded&v=vaTrdHqMHpU" target="_blank">**Project Excercise Development Environment Setup**</br><img src="http://img.youtube.com/vi/vaTrdHqMHpU/default.jpg" 
alt="Project Excercise Development Environment Setup" width="120" height="90" border="1" /></a>

### Chinese 中文
<a href="http://www.youtube.com/watch?feature=player_embedded&v=NtGRqajrjfY
" target="_blank">**开发环境说明**</br><img src="http://img.youtube.com/vi/NtGRqajrjfY/default.jpg" 
alt="Project Excercise Development Environment Setup" width="120" height="90" border="1" /></a>

## Requirements

This project is to build an online exam service that user can create their own exam series with question and answer. 

- User performs signup and login with user email and password
- User creates exam, adds multiple questions with choice answers
- User shares its exam to students through URL, Social medias
- Student will access the exam and take exam with his/her own account
- The student will get scores. Optionally the student can review the mistakes with correct answers


## Technical Specification
This is a .net MVC project connected to database remotely with SQL authentication. It will use Entity Framework Database First to map tables/views to our codes.

This service will implement on IIS web server. 

## Development Stages
1. Bronze
  * UI Design: Theme, Logo
  * Database Design: Table designs
  * Create new/update/delete Exam and its questions
  * User's dashboard shows reports of student's score
  * Students take exam and get scores
  * Globalization and international
2. Silver
  * Administration development / User management
  * A popular ranking page
  * Notifications to students the update of exam promotion
  * Social media plugins
  * Attractive animations
  * Performance tuning
  * Test: functional test, stress test, UAT
3. Gold
  * Setup servers
  * Go live

## Tasks
    1. UI Design: 
        1.1 Theme
        1.2 Logo
        1.3 Banner page for introduction in Home page
    2. Data modeling:
        2.1 Define user information and create T-SQL scripts
        2.2 Define exam table structure and create T-SQL scripts
        2.3 Define question table structure and create T-SQL scripts
        2.4 Define user - exam table structure and create T-SQL scripts
        2.5 Define user activity log table structure and create T-SQL scripts
    3. Business layer design:
        3.1 Page to add/update/delete exam
        3.2 Page to add/update/delete questions, choices and answers
        3.3 Page to take exam and score
    4. Data layer design:
        4.1 Create store procedure for 3.1
        4.2 Create store procedure for 3.2
        4.3 Create store procedure for 3.3

## Contacts
- Twitter: @georgejxzhang
- 微信群： 一个月SQL学习
