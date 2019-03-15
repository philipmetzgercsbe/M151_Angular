import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {TodoService} from './todo.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private url = 'https://localhost:44345/api/todo';
  public $todos:Observable<TodoService[]>;
  constructor(private http:HttpClient) {
    this.getGlobalData();
   }
  getData() {
    return this.http.get(`${this.url}`);
  }
  
  postData(object:TodoService):Observable<TodoService>{
    const httpOptions = {
      headers: new HttpHeaders ({
          'Content-Type': 'application/json',
      })
  };
  return this.http.post<TodoService>(`${this.url}`, object, httpOptions);
  }
  deleteData(object:TodoService):Observable<TodoService>{
    
    
  return this.http.delete<TodoService>(`${this.url}/${object.id}`);
  }
  public getGlobalData():void {
    this.$todos = this.getToDoData();
  }
  public getToDoData():Observable<TodoService[]>{
    
    return this.http.get<TodoService[]>(`${this.url}`);
  }
  public putData(object:TodoService):Observable<TodoService> {
    return this.http.put<TodoService>(`${this.url}/${object.id}`, object);
  }
}
