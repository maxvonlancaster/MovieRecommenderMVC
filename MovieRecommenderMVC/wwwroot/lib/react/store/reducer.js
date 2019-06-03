const initialPagging = {
    pageSize: 10,
    pageNumber: 1,
    sortBy: null,
    isDescending: null,
    searchBy: null,
    searchText: "",
    totalPages: null,
}

const reducer = (state = initialPagging, action) => {
    const newState = Object.assign({}, state);
    if (action.type === 'submit') {
        newState.pageSize = action.val[0];
        newState.pageNumber = action.val[1];
        newState.sortBy = action.val[2];
        newState.isDescending = action.val[3];
        newState.searchBy = action.val[4];
        newState.searchText = action.val[5];
    }
    return newState;
}

export default reducer;