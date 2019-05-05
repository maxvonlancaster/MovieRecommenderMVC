import React, { Component } from 'react';

export default class Grid extends Component {
    constructor() {
        super();
        this.state = {
            data: [],
            error: null
        }
    }
    componentDidMount() {
        fetch("Movie/getAllMovies")
            .then(res => res.json())
            .then((result) => { console.log(result); this.setState({data : result}) })
        //const xhr = new XMLHttpRequest();
        //let url = "api/GetAll";
        //xhr.open('GET', url, true);
        //console.log(xhr.statusText);
        //this.setState({ data: JSON.parse(xhr.responseText) })
    }

    tableHeaders() {
        return(
        <thead>
        <tr>
            <th>MovieId</th>
            <th>Name</th>
            <th>Genre</th>
        </tr>
    </thead>)
    }

    tableBody() {
        const data = this.state.data;
        return (
            data.map(function (row) {
                return (<tr><td>{row.movieId}</td><td>{row.name}</td><td>{row.ganre}</td></tr>)
            })
            )
    }

    renderMovies() {
        const data = this.state.data;
        return data.map(item => {
            return <div>id = {item.movieId}, Name = {item.name}, Ganre = {item.ganre} </div>})
    }

    render() {
        return (<div>
            <h4>Hello </h4>
            <div>{this.renderMovies()}</div>

            <table className="table table-bordered table-hover">
                {this.tableHeaders()}
                <tbody>{this.tableBody()}</tbody>
            </table>
        </div>)
    }
}