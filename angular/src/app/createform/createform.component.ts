import { Component, OnInit } from '@angular/core';
import {ConfigService} from '../service/config.service';
import {TodoService} from '../service/todo.service';
import {FormGroup,Validators,FormBuilder, FormControl} from '@angular/forms';

@Component({
  selector: 'app-createform',
  templateUrl: './createform.component.html',
  styleUrls: ['./createform.component.css']
})
export class CreateformComponent implements OnInit {

  private toDo: TodoService;
  public messageForm: FormGroup;
  submitted = false;
  success = false;
  selected: string; 
  
  options = [
    {name:"low", value:1},
    {name:"medium",value:2},
    {name:"high",value:3}
  ];
  
  constructor(public configs: ConfigService,public FormBuilder: FormBuilder) {
    this.messageForm = this.FormBuilder.group({
        name: ['',Validators.required],
        desc: ['',[Validators.required, Validators.minLength(10)]],
        nameofp: ['',Validators.required],
        enddate: ['',Validators.required],
        importance: ['', Validators.required]
    })
    this.toDo = {
      Name: undefined,
      NameofPerson: undefined,
      ShortDescription: undefined,
      Importance: undefined,
      EndDate: undefined
    }
   }

  ngOnInit() {
  }
  createTodo(event:any):void {
    this.submitted = true;
    if(this.messageForm.invalid){
      return;
    }
    else {
      this.success = true;
      this.configs.postData(this.toDo).subscribe((data: TodoService)=> {
      this.toDo = {
       Name: undefined,
       NameofPerson: undefined,
       ShortDescription: undefined,
       Importance: undefined,
       EndDate: undefined
      }
    });
    }
    
   }

}
