export interface IPeople{
    name: string;
    gender: string;
    age: number;
    pets: IPet[];
}

export interface IPet{
    name: string;
    type: string;
}

export interface PetNamesByOwnerGender{
    gender: string;
    pets: string[];
}


export class PetList{
    constructor( public gender:string, public petNames:string[]){

    }
}

