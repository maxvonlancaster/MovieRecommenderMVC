import React, { Component } from 'react';
import ReactDOM from 'react-dom';

export default class Grid extends Component {
    constructor() {
        super();
        this.state = {
            data: [],
            error: null
        };
    }

    componentDidMount() {
        fetch("Movie/getAllMovies")
            .then(res => res.json())
            .then((result) => { this.setState({data : result}) })
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
                    <th className="action-column">MovieId</th>
            <th>Name</th>
                    <th className="genre-column">Genre</th>
                    <th className="action-column">Update</th>
                    <th className="action-column">Delete</th>
        </tr>
    </thead>)
    }

    tableBody() {
        const data = this.state.data;

        return (
            data.map(function (row) {
                return (<tr id={row.movieId}><td>{row.movieId}</td><td>{row.movieName}</td><td>{row.movieGanre}</td>
                    <td>
                        <a
                            className="glyphicon glyphicon-pencil"
                            aria-hidden="true"
                            onClick={() => { updateMovie(row.movieId) }}>
                        </a>
                    </td>
                    <td>
                        <a
                            className="glyphicon glyphicon-remove"
                            aria-hidden="true"
                            onClick={() => {deleteMovie(row.movieId)}}>
                        </a>
                    </td>
                </tr>)
            })
        )

        function updateMovie(id) { };

        function deleteMovie(id) {
            console.log(id);
            const response = fetch("Movie/deleteMovie", {
                method: 'POST',
                headers: {
                    'accept': 'application/json',
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    'movieId': id,
                    'movieName': null,
                    'movieGanre': null
                }),
            }).then(document.getElementById(id).remove());
        }
    }

    //deleteMovie(id) {
    //    const response = fetch("Movie/addMovie", {
    //        method: 'POST',
    //        headers: {
    //            'accept': 'application/json',
    //            'content-type': 'application/json'
    //        },
    //        body: JSON.stringify({
    //            'id': id
    //        })
    //    });

    //}

    //renderMovies() {
    //    const data = this.state.data;
    //    return data.map(item => {
    //        return <div>id = {item.movieId}, Name = {item.name}, Ganre = {item.ganre} </div>})
    //}

    render() {
        return (<div>
            <h4>Hello </h4>

            <table className="table table-bordered table-hover">
                {this.tableHeaders()}
                <tbody>{this.tableBody()}</tbody>
            </table>
        </div>)
    }
}