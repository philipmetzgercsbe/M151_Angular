import { Component, OnInit } from '@angular/core';
import {ConfigService} from '../service/config.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  visible: string = '';
  

  constructor(
    public cs : ConfigService
  ) { 
    
  }

  
  toggle(shouldBeVisible:string){
    if(this.visible === shouldBeVisible){
      this.visible = '';
    }else{
      this.visible = shouldBeVisible;
    }
  
    
  }
 
 
  ngOnInit() {
  }

}
