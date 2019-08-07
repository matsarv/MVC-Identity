import React, { Component } from 'react';

const ListTableHeader = () => {
    return (
        <thead>
            <tr>
                {/* <th>Id</th> */}
                <th>Firstname</th>
                <th>Lastname</th>
                <th>Email</th>
                <th>Phone</th>
                <th>City</th>
                <th colSpan={3}>Edit/Delete</th>
                {/* <th colSpan={3}>Edit - View - Delete</th> */}
            </tr>
        </thead>
    );
}

const ListTableBody = props => {
    const rows = props.characterData.map((row, index) => {
        return (
            <tr key={row.id}>
                {/* <td>{row.id}</td> */}
                <td>{row.firstName}</td>
                <td>{row.lastName}</td>
                <td>{row.email}</td>
                <td>{row.phone}</td>
                <td>{row.cityId}</td>
                <td>
                    <button title="Edit" onClick={() => props.editCharacter(row.id)}
                        className="btn btn-sm btn-primary">
                        <i className="far fa-edit" aria-hidden="true"></i>
                    </button>
                </td>
                {/* <td>
                    <button title="Edit" onClick={() => props.editCharacter(row.id)}
                        className="btn btn-sm btn-primary">
                        <i class="fa fa-info-circle"></i>
                    </button>
                </td> */}
                <td>
                    <button title="Delete" onClick={() => props.deleteCharacter(row.id)}
                        className="btn btn-sm btn-primary">
                        <i className="fa fa-trash"></i>
                    </button>
                </td>
            </tr>
        );
    });

    return <tbody>{rows}</tbody>;
}

class ListTable extends Component {
    render() {
        const { characterData, deleteCharacter, editCharacter } = this.props;

        return (
            <table className="table table-bordered table-striped">
                <ListTableHeader />
                <ListTableBody characterData={characterData} deleteCharacter={deleteCharacter} editCharacter={editCharacter} />
            </table>
        );
    }
}

export default ListTable;