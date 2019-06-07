import React, { Component } from 'react';
import FilterTypes from "../constants/FilterTypes";
import { connect } from 'react-redux';

class Filter extends Component {
    constructor(props) {
        super(props)
        this.state = {
            pageSize: 10,
            pageNumber: null,
            sortBy: null,
            isDescending: null,
            searchBy: null,
            searchText: "",
            columns: {
                "Movie Id": "movieId",
                "Movie Name": "movieName",
                "Movie Ganre": "movieGanre",
            }
        }

        this.handleDropDownChangeFilter = this.handleDropDownChangeFilter.bind(this);
        this.setDropDownList = this.setDropDownList.bind(this);
        this.handleChangeFilter = this.handleChangeFilter.bind(this);

        this.setDropDownListPager = this.setDropDownListPager.bind(this);
        this.handleDropDownChangePager = this.handleDropDownChangePager.bind(this);
        this.handleSubmitFilter = this.handleSubmitFilter.bind(this);

        this.submitClicked = this.submitClicked.bind(this);
    }

    handleDropDownChangeFilter(e) {
        this.setState({
            searchBy: FilterTypes[this.state.columns[e.target.value]]
        })
    }

    handleDropDownChangePager(e) {
        this.setState({
            pageSize: e.target.value,
        })
    }

    setDropDownList() {
        return Object.keys(this.state.columns).map(function (column) {
            return <option key={column} >{column}</option>
        })
    }

    setDropDownListPager() {
        var paging = [10,20,50,100]
        return paging.map(function (number) {
            return <option key={number} >{number}</option>
        })
    }

    handleChangeFilter(e) {
        this.setState({
            searchText: e.target.value
        })
    }

    handleSubmitFilter(e) {
        var values = [Number(this.state.pageSize),
            this.state.pageNumber === null ? 1 : this.state.pageNumber,
            this.state.sortBy,
            this.state.isDescending,
            this.state.searchBy,
            this.state.searchText];
        this.props.setValue(values);
        e.preventDefault();
    }

    submitClicked(e) {
        e.preventDefault();
    }


        render() {
            return (
                <div>
                    <form className="form" onSubmit={this.handleSubmitFilter} id="filter-form" target="hiddenFrame"
                        >
                    <div className="container">
                    <div className="row">
                            <div className="col-xs-2">

                        <label className="label-dafault label-form-update">Search by:</label>
                        <select id="filter-select" className="label-form-update"
                            onChange={this.handleDropDownChangeFilter}>
                            {this.setDropDownList()}
                        </select>
                    </div>
                            <div className="col-xs-2">
                        <label className="label-dafault label-form-update">Search text</label>
                        <input
                            id="filter-input"
                                    className="label-form-update"
                                    name="no-redirect"
                            value={this.state.searchText}
                            onChange={this.handleChangeFilter}/>
                            </div>
                            <div className="col-xs-2">
                                <div>
                                    <label className="label-dafault label-form-update">Items per page:</label>
                                </div>
                                    <select id="filter-select-paging" className="label-form-update"
                                    onChange={this.handleDropDownChangePager}>
                                    {this.setDropDownListPager()}
                                </select>
                            </div>
                            <div className="col-xs-1">
                                <div>
                                    <button className="glyphicon glyphicon-chevron-left" />
                                    <button className="glyphicon glyphicon-chevron-right" />
                                </div>
                            </div>
                            <div className="col-xs-1">
                    <div>
                        <input type="submit" value="Submit" className="btn--cta" id="button-filter-submit" />
                        </div>
                        </div>
                        </div>
                        </div>
                </form>
                    <iframe name="hiddenFrame" width="0" height="0" border="0" style={{ display: "none" }}></iframe>
                </div>
                    )
        }

    
} 

const mapStateToProps = (state) => {
    return {
        pagingModel: {
            pageSize: state.pageSize,
            pageNumber: state.pageNumber,
            sortBy: state.sortBy,
            isDescending: state.isDescending,
            searchBy: state.searchBy,
            searchText: state.searchText,
        }
    }
}

const mapDispatchToProps = (dispatch) => {
    return { 
        setValue: (values) => dispatch({ type: "submit", val: values })
    }
}


export default connect(mapStateToProps, mapDispatchToProps)(Filter);

