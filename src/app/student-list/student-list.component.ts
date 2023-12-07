import { Component, OnInit } from '@angular/core';
import { Student } from './Models/student.model';
import { StudentService } from '../student.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.scss'
})
export class StudentListComponent implements OnInit{
  
  students$?: Observable<Student[]>;

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
    console.log(this.studentService.getAllStudents());
  }
}
