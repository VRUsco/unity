from flask import Flask, request, jsonify
from flask_cors import CORS
from sqlalchemy import create_engine
from sqlalchemy import text
from pandas import DataFrame


app = Flask(__name__)
CORS(app)

users = []
engine = create_engine('postgresql://pruebas:pruebas@localhost:5434/oriespacial')

@app.route("/puntaje", methods=["POST"])
def starting_url():
    json_data = request.json
    user = json_data["usuario"]
    errores = json_data["errores"]
    data = {"usuario":user,"errores":errores}
   
    sql = text('insert into resultados (usuario, errores) values ('+str(user)+','+str(errores)+')')
    engine.execute(sql)
    users.append(data)
    return {"data":data}

@app.route('/list', methods=["GET"])
def show_form_data():
    sql = text('select u.id as usuario_id, u.name, r.puntaje from usuarios as u, resultados as r where u.id = r.usuario')
    result = engine.execute(sql)

    # convert sqlalchemy.engine.result to pandas dataframe
    dataframe = DataFrame(result.fetchall())
    dataframe.columns = result.keys()
    data_json = dataframe.to_json(orient='records')
    return jsonify(data_json)

if __name__ == '__main__':
    #app.run(host="0.0.0.0", port=8080)
    app.run()