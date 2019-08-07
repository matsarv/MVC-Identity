import React, { Component, Fragment } from "react";
import axios from "axios";
import ListTable from "./tables/ListTable";
import AddUserForm from "./forms/AddUserForm";
import EditUserForm from "./forms/EditUserForm";

class App extends Component {

  state = {
    characters: [],
    dataFail: false,
    dataMsg: null,
    editing: false
  };

  componentDidMount() {
    this.getCharacters()
    this.setState({ editing: false });
  }


  //************** CRUD **************\\

  // CREATE
  addCharacter = character => {

    axios
      .post(`https://localhost:44399/api/PeopleAPI/`, character)
      .then(response => {
        // console.log(response.data);
        const characterList = this.state.characters;
        // console.log(characterList);
        characterList.push(response.data);
        // console.log(characterList);
        this.setState({ characters: characterList })
      })
      .catch(status => {
        console.error(status);
        this.setState({ dataMsg: status.message });
      })
  };

  //READ ONE
  editCharacter = id => {

    this.setState({ editing: true });
    // console.log(id);

    const characterList = this.state.characters;
    // console.log(characterList)
    const character = characterList.find(x => x.id === id);
    // console.log(character)

    this.setState({ editCharacter: character });
  };

  //READ ALL
  getCharacters() {

    return axios
      .get('https://localhost:44399/api/PeopleAPI/')
      .then(response => {
        // console.log(response.data);
        const characters = response.data;
        this.setState({ characters });
      })
      .catch(
        function (error) {
          console.error(error);
          this.setState({ dataFail: true });
          if (error.response) {
            // The request was made and the server responded with a status code
            // that falls out of the range of 2xx
            this.setState({
              dataMsg: "Sever Access Denied: " + error.response.status
            });
          } else if (error.request) {
            // The request was made but no response was received
            // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
            // http.ClientRequest in node.js
            this.setState({ dataMsg: "Sever did not respond. " + error.message });
          } else {
            // Something happened in setting up the request that triggered an Error
            this.setState({ dataMsg: "Failed to send your request. " + error.message });
          }
        }.bind(this)
      );
  }

  // UPDATE
  updateCharacter = character => {

    this.setState({ editing: false });

    // console.log("updateCharacter...");
    // console.log(character);
    const id = character.id;
    // console.log(id);

    axios
      .put(`https://localhost:44399/api/PeopleAPI/${id}`, character)
      .then(response => {
        // console.log(response.data);
        // console.log(response.data.id);
        const characterList = this.state.characters;
        // console.log(characterList);
        const index = characterList.findIndex(x => x.id === response.data.id);
        // console.log(index);

        if (index !== -1) {
          characterList.splice(index, 1, response.data);
          // console.log(characterList);
          this.setState({ characters: characterList });
        }
      })
      .catch(status => {
        console.error(status);
        this.setState({ dataMsg: status.message });
      })
  };

  // DELETE
  deleteCharacter = id => {

    // console.log(id);
    axios
      .delete(`https://localhost:44399/api/PeopleAPI/${id}`)
      .then(response => {
        // console.log(response.data);
        let characterList = this.state.characters;
        // console.log(characterList);
        characterList = characterList.filter(x => x.id !== id);
        // console.log(characterList);
        this.setState({ characters: characterList });
      })
      .catch(status => {
        console.error(status);
        this.setState({ dataMsg: status.message });
      })
  };

  //************ CRUD Ends ************\\




  render() {
    const { characters, editCharacter, dataFail, dataMsg } = this.state;
    // console.log(characters.length);

    const { editing } = this.state;
    // console.log(editing);

    let message = "";
    if (dataFail) {
      message =
        <button className="btn btn-danger m-1" disabled>
          <div><i className="fas fa-cog fa-spin"></i> {dataMsg} <i className="fas fa-cog fa-spin"></i></div>
        </button>
    };

    return (
      <div className="container">



        <h1>REACT MVC CRUD</h1>
        <h5>MVC Identity - Persons Table</h5>

        {message}

        <div className="flex-row">

          <div className="flex-large">
            <h3>List People</h3>
            <p>List of people in database.</p>
            <ListTable
              characterData={characters}
              deleteCharacter={this.deleteCharacter}
              editCharacter={this.editCharacter}
            />
          </div>

          {editing ? (

            <Fragment>
              <div className="flex-small">
                <h3>Edit Person</h3>
                <p>Edit persons data from the table.</p>
                <EditUserForm editCharacter={editCharacter} updateCharacter={this.updateCharacter} />
              </div>
            </Fragment>

          ) : (

              <Fragment>

                <div className="flex-small">
                  <h3>Add new Person</h3>
                  <p>Add person data to the table.</p>
                  <AddUserForm addCharacter={this.addCharacter} />
                </div>
              </Fragment>

            )}

        </div>
      </div>
    );
  }
}

export default App;
