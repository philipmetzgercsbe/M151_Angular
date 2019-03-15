import { Component, OnInit, Input } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ConfigService} from '../service/config.service';
import {TodoService} from '../service/todo.service';

@Component({
  selector: 'app-displayform',
  templateUrl: './displayform.component.html',
  styleUrls: ['./displayform.component.css']
})
export class DisplayformComponent implements OnInit {

  constructor(private http:HttpClient, public cs: ConfigService) { }
  todos:Object;
  @Input() toDo: TodoService;

  ngOnInit() {
    this.cs.getData().subscribe(data=>{
      this.todos = data
      console.log(this.todos)
    })
  }
  public deleteToDo():void {
   
  }

}
