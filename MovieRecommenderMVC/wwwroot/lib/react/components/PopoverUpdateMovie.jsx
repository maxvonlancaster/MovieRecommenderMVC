import React, { Component } from 'react';
import { Button, Popover, PopoverHeader, PopoverBody } from 'reactstrap';

export default class PopoverUpdateMovie extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: props.data || null,
            target: props.target || null,
            popoverOpen: false,
            genres: props.genres || [],
            MovieGanre: props.MovieGanre || "",
        }
        this.toggle = this.toggle.bind(this);
        this.handleSubmitUpdate = this.handleSubmitUpdate.bind(this);
        this.handleChangeUpdate = this.handleChangeUpdate.bind(this);
        this.handleDropDownChangeUpdate = this.handleDropDownChangeUpdate.bind(this);
    }

    toggle() {
        this.setState({
            popoverOpen: !this.state.popoverOpen
        });
    }

    setDropDownList() {
        return this.state.genres.map(function (genre) {
            return <option>{genre.genreName}</option>
        })
    }

    handleChangeUpdate(e) {
        console.log(e.target.value);
        //this.state.data.movieName = e.target.value;
        this.setState({ data: { movieName: e.target.value, movieGanre: this.state.data.movieGanre } });
    }

    handleChangeGanreUpdate(e) {
        this.state.data.movieGanre = e.target.value;
        //this.setState({ MovieGanre: e.target.value });
    }

    handleSubmitUpdate(e) {
        e.preventDefault();
        console.log(this.state.data);

        if (this.state.data.movieGanre == "") {
            this.state.data.movieGanre = this.state.genres[0].genreName;
        };

        const response = fetch("Movie/updateMovie", {
            method: 'POST',
            headers: {
                'accept': 'application/json',
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                'movieId': this.state.data.movieId,
                'movieName': this.state.data.movieName,
                'movieGanre': this.state.data.movieGanre
            })
        });

        this.toggle();
        location.reload();
        //this.setState({
        //    MovieName: "",
        //    MovieGanre: ""
        //});
    }

    handleDropDownChangeUpdate(e) {
        this.state.data.movieGanre = e.target.value;
        //this.setState({ MovieGanre: e.target.value });
    }


    render() {
        const formId = "form" + this.state.target;
        const buttonId = "button" + this.state.target;
        const inputId = "input" + this.state.target;
        const selectId = "select" + this.state.target;

        return (
            <div>
                <a
                    id={this.state.target}
                    className="glyphicon glyphicon-pencil"
                    aria-hidden="true">
                </a>
                <Popover
                    className="custom-update-popover"
                    placement="top"
                    isOpen={this.state.popoverOpen}
                    target={this.state.target}
                    toggle={this.toggle}
                    onDoubleClick={this.toggle}
                    >
                    <PopoverHeader>Update this movie</PopoverHeader>
                    <PopoverBody>
                        <form className="form" onSubmit={this.handleSubmitUpdate} id={formId}>
                            <div className="form-group">
                                <label className="label-dafault label-form-update">Movie name</label>
                            <input
                                    id={inputId}
                                    className="label-form-update"
                                name={inputId}
                                value={this.state.data.movieName}
                                onChange={this.handleChangeUpdate}
                                    required />
                            </div>
                            <div className="form-group">
                                <label className="label-dafault label-form-update">Movie genre</label>
                                <select id={selectId} className="label-form-update"
                                    onChange={this.handleDropDownChangeUpdate}>
                                {this.setDropDownList()}
                                </select>
                            </div>
                            <div className="form-group">
                                <input type="submit" value="Submit" className="btn--cta" id={buttonId} />
                            </div>
                        </form>
                    </PopoverBody>
                </Popover>
            </div>
            )
    }
}
