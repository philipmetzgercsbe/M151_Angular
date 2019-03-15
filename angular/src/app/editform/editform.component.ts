import { Component, OnInit,Input} from '@angular/core';
import { TodoService } from '../service/todo.service';
import {ConfigService} from '../service/config.service';

@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['./editform.component.css']
})
export class EditformComponent implements OnInit {
  @Input() toDo$: TodoService;
  constructor(
    public cs:ConfigService
  ) { }
  
  ngOnInit() {
  }
  public delete(event?:any):void {
    this.cs.deleteData(this.toDo$).subscribe((data:TodoService)=>{
      this.cs.getGlobalData();
    })
  }
  public change(event?:any):void {
    this.cs.putData(this.toDo$).subscribe((data:TodoService)=> {
      this.cs.getGlobalData();
    })
  }
}
