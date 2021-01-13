import React from 'react';
import jquery, { data } from "jquery";
export class Userform extends React.Component{
    constructor(){
        super();
        this.state={
            name:'Ram',
            age:30,
            gender:'F'
        }
    }
    render(){
        return (
            <div>
            <div>Userform</div>
            <input value={this.state.name} onChange={this.updateName.bind(this)}></input>
            <input value={this.state.age}></input>
            <input value={this.state.gender}></input>
            <input type="radio" value="Male" name="gender" /> Male
            <input type="radio" value="Female" name="gender" /> Female
            <input type="radio" value="Other" name="gender" /> Other
            <br/>
            <button onClick={this.save=this.save.bind(this)}>save</button>
            </div>
        )
    }
    save(event){
        console.log(this.state);
        //ajax code
        jquery.ajax({
            url:"http://localhost:4200/users",
            type:'POST',
            data: this.state,

        })
        
    }
    updateName(event){
        this.setState({name:event.target.value});
    }
}