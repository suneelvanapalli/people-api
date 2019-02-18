import { Component, OnInit } from '@angular/core';
import { PeopleService } from './people.service';
import { IPeople, PetList , PetNamesByOwnerGender } from './people';

@Component({
  selector: 'pm-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {  

  constructor(private peopleService: PeopleService) { }

  peopleList: PetNamesByOwnerGender[];
  errorMessage: string = '';

  ngOnInit() {
    var petNamesList:PetList[] = [];
      this.peopleService.getPeople().subscribe(
        people => {
          this.peopleList = people;               
        },
        error =>{
          this.errorMessage = error;
        }
      )
  }
}
