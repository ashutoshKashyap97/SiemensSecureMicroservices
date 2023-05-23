import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-process',
  templateUrl: './process.component.html',
  styleUrls: ['./process.component.css']
})
export class ProcessComponent {
  title = 'hello';
  works : any;

  constructor(private http: HttpClient){

  }
  
  ngOnInit(): void {
    this.http.get('https://localhost/api/works').subscribe({
      next: (response: any) => this.works = response,
      error : (error: any)=> console.log(error),
      complete: () => console.log('Request complete') 
    })
  }
}
